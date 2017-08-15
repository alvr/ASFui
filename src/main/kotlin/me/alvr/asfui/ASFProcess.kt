package me.alvr.asfui

import java.nio.file.Path
import javafx.beans.property.SimpleBooleanProperty
import javafx.scene.control.TextArea
import me.alvr.asfui.util.ConfigValues
import org.zeroturnaround.exec.ProcessExecutor
import org.zeroturnaround.exec.StartedProcess
import org.zeroturnaround.exec.stream.LogOutputStream
import tornadofx.Controller
import tornadofx.property

object ASFProcess : Controller() {
    override val configPath: Path = app.configBasePath.resolve("asfui.properties")

    private lateinit var process: StartedProcess

    private val startedProperty = SimpleBooleanProperty(this, "process", false)
    var started by property(startedProperty)

    fun start(output: TextArea) {
        if (!started.value) {
            process = ProcessExecutor()
                    .command(config.string(ConfigValues.BINARY), "--server")
                    .redirectOutput(object : LogOutputStream() {
                        override fun processLine(line: String?) {
                            output.appendText("$line\n")
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
