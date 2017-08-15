package me.alvr.asfui

import java.nio.file.Path
import javafx.scene.control.TextArea
import me.alvr.asfui.util.ConfigValues
import org.zeroturnaround.exec.ProcessExecutor
import org.zeroturnaround.exec.StartedProcess
import org.zeroturnaround.exec.stream.LogOutputStream
import tornadofx.Controller

object ASFProcess : Controller() {
    override val configPath: Path = app.configBasePath.resolve("asfui.properties")

    private lateinit var process: StartedProcess
    var started = false

    fun start(output: TextArea) {
        if (!started) {
            process = ProcessExecutor()
                    .command(config.string(ConfigValues.BINARY), "--server")
                    .redirectOutput(object : LogOutputStream() {
                        override fun processLine(line: String?) {
                            output.appendText("$line\n")
                        }
                    })
                    .destroyOnExit()
                    .start()
            started = true
        }
    }

    fun stop() {
        if (started) {
            started = false
            process.process.destroy()
        }
    }
}