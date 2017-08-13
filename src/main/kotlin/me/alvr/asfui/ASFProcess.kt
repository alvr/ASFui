package me.alvr.asfui

import javafx.scene.control.TextArea
import org.zeroturnaround.exec.ProcessExecutor
import org.zeroturnaround.exec.StartedProcess
import org.zeroturnaround.exec.stream.LogOutputStream

object ASFProcess {
    private lateinit var process: StartedProcess
    var started = false

    fun start(output: TextArea) {
        if (!started) {
            process = ProcessExecutor()
                    .command(Configuration.getPropertyString(Configuration.BINARY, Configuration.BINARY_DEFAULT), "--server")
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