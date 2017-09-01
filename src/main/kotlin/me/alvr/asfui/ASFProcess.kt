package me.alvr.asfui

import javafx.beans.property.SimpleBooleanProperty
import javafx.scene.control.TextArea
import me.alvr.asfui.util.ConfigManager
import me.alvr.asfui.util.ConfigValues
import org.controlsfx.control.Notifications
import org.zeroturnaround.exec.ProcessExecutor
import org.zeroturnaround.exec.StartedProcess
import org.zeroturnaround.exec.stream.LogOutputStream
import tornadofx.Controller
import tornadofx.property
import tornadofx.runLater
import kotlin.properties.Delegates

object ASFProcess : Controller() {
    private lateinit var process: StartedProcess
    private val startedProperty = SimpleBooleanProperty(false)
    var started: SimpleBooleanProperty by property(startedProperty)

    var output: TextArea by Delegates.notNull()
    var input: TextArea by Delegates.notNull()

    fun start() {
        if (!started.value) {
            process = ProcessExecutor()
                    .command(ConfigManager.string(ConfigValues.BINARY), "--server")
                    .redirectOutput(object : LogOutputStream() {
                        override fun processLine(line: String?) {
                            output.appendText("$line${System.lineSeparator()}")
                            handleOutput(line)
                        }
                    })
                    .destroyOnExit()
                    .start()

            started.value = true
        }
    }

    fun stop() {
        if (started.value) {
            started.value = false
            process.process.destroy()
        }
    }

    private fun handleOutput(line: String?) {
        line?.let {
            val data = line.trim()

            if (data.endsWith("Update process finished!")) {
                stop()
                start()
            }

            if (data.contains("Finished idling:") && ConfigManager.boolean(ConfigValues.NOTIFICATIONS)) {
                val gameFinishedRegex = Regex(".*\\|.*\\|.*\\|(.*)\\|.* \\d+ \\((.*)\\) .*")
                if (gameFinishedRegex.matches(data)) {
                    val match = gameFinishedRegex.find(data)
                    match?.let {
                        val user = match.groups[1]!!.value
                        val game = match.groups[2]!!.value
                        runLater {
                            Notifications.create()
                                    .title("Idling finished!")
                                    .text("$user has finishing farming all the cards from $game.")
                                    .showInformation()
                        }
                    }
                }
            }

            val keyRegex = Regex(".*Key: (.*) \\| Status: .*(NoDetail|Fail/DuplicateActivationCode|Fail/BadActivationCode|Fail/AlreadyPurchased|Fail/RateLimited)")
            if (keyRegex.matches(data)) {
                val match = keyRegex.find(data)
                match?.let {
                    val key = match.groups[1]!!.value
                    val type = match.groups[2]!!.value

                    if ((type.contains("NoDetail") && ConfigManager.boolean(ConfigValues.REDEEMED)) ||
                            (type.contains("DuplicateActivationCode") && ConfigManager.boolean(ConfigValues.DUPLICATED)) ||
                            (type.contains("BadActivationCode") && ConfigManager.boolean(ConfigValues.INVALID)) ||
                            (type.contains("AlreadyPurchased") && ConfigManager.boolean(ConfigValues.OWNED)) ||
                            (type.contains("RateLimited") && ConfigManager.boolean(ConfigValues.COOLDOWN))) {
                        input.text = input.text.replace(key, "")
                    }
                }
            }
        }
    }
}