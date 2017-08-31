package me.alvr.asfui

import javafx.application.Application
import javafx.application.Platform
import javafx.scene.image.Image
import javafx.stage.Stage
import me.alvr.asfui.util.ConfigManager
import me.alvr.asfui.util.ConfigValues
import me.alvr.asfui.util.getCurrentVersion
import me.alvr.asfui.views.MainWindow
import org.apache.commons.io.FileUtils
import tornadofx.App
import tornadofx.FX
import java.awt.SystemTray
import java.io.File

class ASFui : App(MainWindow::class) {
    override fun start(stage: Stage) {
        super.start(stage)
        stage.icons += Image("/icons/logo.png")
        stage.isResizable = false

        stage.iconifiedProperty().addListener { _, _, newState ->
            if (newState && ConfigManager.boolean(ConfigValues.TO_TRAY)) {
                FX.primaryStage.isIconified = true
                FX.primaryStage.hide()

                trayicon(resources.stream("/icons/tray.png"), "ASFui v${getCurrentVersion()}") {
                    setOnMouseClicked(fxThread = true) {
                        FX.primaryStage.isIconified = false
                        FX.primaryStage.show()
                        FX.primaryStage.toFront()
                    }

                    menu("ASFui") {
                        item("Show Window") {
                            setOnAction(fxThread = true) {
                                FX.primaryStage.show()
                                FX.primaryStage.toFront()
                            }
                        }
                        item("Exit") {
                            setOnAction(fxThread = true) {
                                Platform.exit()
                            }
                        }
                    }
                }
            }

            if (!newState && ConfigManager.boolean(ConfigValues.TO_TRAY)) {
                SystemTray.getSystemTray().trayIcons.forEach {
                    SystemTray.getSystemTray().remove(it)
                }
            }
        }
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