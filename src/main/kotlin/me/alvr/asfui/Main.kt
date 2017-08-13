package me.alvr.asfui

import javafx.application.Application
import javafx.scene.image.Image
import javafx.stage.Stage
import me.alvr.asfui.views.MainWindow
import tornadofx.App

class ASFui : App(MainWindow::class) {
    override fun start(stage: Stage) {
        super.start(stage)
        stage.icons += Image("/icons/logo.png")
    }

    init {
        Configuration.loadProperties()
    }
}

fun main(args: Array<String>) {
    Application.launch(ASFui::class.java, *args)
}