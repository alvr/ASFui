package me.alvr.asfui

import javafx.application.Application
import javafx.scene.image.Image
import javafx.stage.Stage
import me.alvr.asfui.views.MainWindow
import org.apache.commons.io.FileUtils
import tornadofx.App
import java.io.File
import java.nio.file.Path
import java.nio.file.Paths

class ASFui : App(MainWindow::class) {
    override val configBasePath: Path = Paths.get("./")

    override fun start(stage: Stage) {
        super.start(stage)
        stage.icons += Image("/icons/logo.png")
    }

    init {
        if (!File("asfui.properties").exists()) {
            val config = ClassLoader.getSystemResource("asfui.properties")
            FileUtils.copyURLToFile(config, File("asfui.properties"))
        }

        with(config) {
            loadConfig()
        }
    }
}

fun main(args: Array<String>) {
    Application.launch(ASFui::class.java, *args)
}