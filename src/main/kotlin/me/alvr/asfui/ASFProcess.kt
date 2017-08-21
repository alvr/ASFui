package me.alvr.asfui

import javafx.beans.property.SimpleBooleanProperty
import javafx.scene.control.TextArea
import me.alvr.asfui.util.ConfigManager
import me.alvr.asfui.util.ConfigValues
import org.zeroturnaround.exec.ProcessExecutor
import org.zeroturnaround.exec.StartedProcess
import org.zeroturnaround.exec.stream.LogOutputStream
import tornadofx.Controller
import tornadofx.property

object ASFProcess : Controller() {
    private lateinit var process: StartedProcess
    private val startedProperty = SimpleBooleanProperty(this, "process", false)
    var started by property(startedProperty)
    lateinit var output: TextArea

    fun start(output: TextArea) {
        if (!started.value) {
            this.output = output
            process = ProcessExecutor()
                    .command(ConfigManager.string(ConfigValues.BINARY), "--server")
                    .redirectOutput(object : LogOutputStream() {
                        override fun processLine(line: String?) {
                            output.appendText("$line\n")
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
                start(output)
            }
        }
    }
}