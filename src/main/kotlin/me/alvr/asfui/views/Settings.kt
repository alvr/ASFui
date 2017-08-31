package me.alvr.asfui.views

import javafx.animation.PauseTransition
import javafx.scene.control.Button
import javafx.scene.control.CheckBox
import javafx.scene.control.Label
import javafx.scene.control.TextField
import javafx.scene.control.ToggleButton
import javafx.scene.layout.AnchorPane
import javafx.util.Duration
import me.alvr.asfui.util.ConfigManager
import me.alvr.asfui.util.ConfigValues
import me.alvr.asfui.util.checkRemote
import tornadofx.View
import tornadofx.action
import tornadofx.c
import tornadofx.chooseFile
import tornadofx.fade
import tornadofx.onChange

class Settings : View("Settings") {
    override val root: AnchorPane by fxml("/settings.fxml")

    private val searchBinary: Button by fxid("search_binary")
    private val pathBinary: Label by fxid("path_binary")
    private val isLocal: ToggleButton by fxid("local")
    private val isRemote: ToggleButton by fxid("remote")
    private val host: TextField by fxid("host")
    private val redeemed: CheckBox by fxid("redeemed")
    private val duplicated: CheckBox by fxid("duplicated")
    private val invalid: CheckBox by fxid("invalid")
    private val owned: CheckBox by fxid("owned")
    private val cooldown: CheckBox by fxid("cooldown")
    private val autostart: CheckBox by fxid("autostart")
    private val minimizeTray: CheckBox by fxid("minimize_tray")
    private val save: Button by fxid("save")
    private val status: Label by fxid("status")

    init {
        loadSettings()

        searchBinary.action {
            val binary = chooseFile("Select ASF binary", emptyArray()).firstOrNull()
            binary?.let {
                pathBinary.text = binary.path
            }
        }

        save.action {
            if (isRemote.isSelected && !checkRemote(host.text)) {
                status.apply {
                    text = "Invalid remote endpoint."
                    textFill = c(255, 0, 0)
                    fade(Duration.seconds(1.0), 1.0).setOnFinished {
                        val pause = PauseTransition(Duration.seconds(2.0))
                        pause.setOnFinished {
                            fade(Duration.seconds(1.0), 0.0)
                        }
                        pause.play()
                    }
                }
                return@action
            } else {
                ConfigManager.set(ConfigValues.BINARY, pathBinary.text)
                ConfigManager.set(ConfigValues.IS_LOCAL, isLocal.isSelected)
                ConfigManager.set(ConfigValues.IS_REMOTE, isRemote.isSelected)
                ConfigManager.set(ConfigValues.HOST, host.text)
                ConfigManager.set(ConfigValues.REDEEMED, redeemed.isSelected)
                ConfigManager.set(ConfigValues.DUPLICATED, duplicated.isSelected)
                ConfigManager.set(ConfigValues.INVALID, invalid.isSelected)
                ConfigManager.set(ConfigValues.OWNED, owned.isSelected)
                ConfigManager.set(ConfigValues.COOLDOWN, cooldown.isSelected)
                ConfigManager.set(ConfigValues.AUTO_START, autostart.isSelected)
                ConfigManager.set(ConfigValues.TO_TRAY, minimizeTray.isSelected)
                MainWindow.isBinarySelected.value = !ConfigManager.string(ConfigValues.BINARY).isEmpty()
                status.apply {
                    text = "Settings saved."
                    textFill = c(0, 0, 0)
                    fade(Duration.seconds(1.0), 1.0).setOnFinished {
                        val pause = PauseTransition(Duration.seconds(1.25))
                        pause.setOnFinished {
                            fade(Duration.seconds(1.0), 0.0)
                        }
                        pause.play()
                    }
                }
            }
        }

        host.isDisable = !isRemote.isSelected
        isRemote.selectedProperty().onChange {
            host.isDisable = !isRemote.isSelected
        }
    }

    private fun loadSettings() {
        pathBinary.text = ConfigManager.string(ConfigValues.BINARY)
        isLocal.isSelected = ConfigManager.boolean(ConfigValues.IS_LOCAL)
        isRemote.isSelected = ConfigManager.boolean(ConfigValues.IS_REMOTE)
        host.text = ConfigManager.string(ConfigValues.HOST, ConfigValues.HOST_DEFAULT)
        redeemed.isSelected = ConfigManager.boolean(ConfigValues.REDEEMED)
        duplicated.isSelected = ConfigManager.boolean(ConfigValues.REDEEMED)
        invalid.isSelected = ConfigManager.boolean(ConfigValues.INVALID)
        owned.isSelected = ConfigManager.boolean(ConfigValues.OWNED)
        cooldown.isSelected = ConfigManager.boolean(ConfigValues.COOLDOWN)
        autostart.isSelected = ConfigManager.boolean(ConfigValues.AUTO_START)
        minimizeTray.isSelected = ConfigManager.boolean(ConfigValues.TO_TRAY)
    }
}