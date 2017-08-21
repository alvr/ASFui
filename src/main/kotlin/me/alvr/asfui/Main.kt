package me.alvr.asfui

import javafx.application.Application
import javafx.scene.image.Image
import javafx.stage.Stage
import me.alvr.asfui.util.ConfigManager
import me.alvr.asfui.views.MainWindow
import org.apache.commons.io.FileUtils
import tornadofx.App
import java.io.File

class ASFui : App(MainWindow::class) {
    override fun start(stage: Stage) {
        super.start(stage)
        stage.icons += Image("/icons/logo.png")
        stage.isResizable = false
    }

    init {
        if (!File("asfui.properties").exists()) {
            val config = ClassLoader.getSystemResource("asfui.properties")
            FileUtils.copyURLToFile(config, File("asfui.properties"))
        }

        ConfigManager.loadProperties()
    }
}

fun main(args: Array<String>) {
    Application.launch(ASFui::class.java, *args)
}