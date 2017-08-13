package me.alvr.asfui.views

import javafx.animation.PauseTransition
import javafx.scene.control.Button
import javafx.scene.control.CheckBox
import javafx.scene.control.Label
import javafx.scene.control.TextField
import javafx.scene.control.ToggleButton
import javafx.scene.layout.AnchorPane
import javafx.stage.FileChooser
import javafx.util.Duration
import me.alvr.asfui.Configuration
import tornadofx.*

class Settings : View("Settings") {
    override val root: AnchorPane by fxml("/settings.fxml")
    val searchBinary: Button by fxid("search_binary")
    val pathBinary: Label by fxid("path_binary")
    val isLocal: ToggleButton by fxid("local")
    val isRemote: ToggleButton by fxid("remote")
    val host: TextField by fxid("host")
    val redeemed: CheckBox by fxid("redeemed")
    val duplicated: CheckBox by fxid("duplicated")
    val invalid: CheckBox by fxid("invalid")
    val owned: CheckBox by fxid("owned")
    val cooldown: CheckBox by fxid("cooldown")
    val save: Button by fxid("save")
    val status: Label by fxid("status")

    init {
        loadSettings()

        searchBinary.action {
            val chooser = FileChooser()
            val binary = chooser.showOpenDialog(this@Settings.currentWindow)
            binary?.let {
                pathBinary.text = binary.path
            }
        }

        save.action {
            if (isRemote.isSelected && !checkRemote()) {
                status.text = "Invalid remote endpoint."
                status.textFill = c(255, 0, 0)
                status.fade(Duration.seconds(1.0), 1.0).setOnFinished {
                    val pause = PauseTransition(Duration.seconds(2.0))
                    pause.setOnFinished {
                        status.fade(Duration.seconds(1.0), 0.0)
                    }
                    pause.play()
                }
               return@action
            } else {
                Configuration.setProperty(Configuration.BINARY, pathBinary.text)
                Configuration.setProperty(Configuration.IS_LOCAL, isLocal.isSelected)
                Configuration.setProperty(Configuration.IS_REMOTE, isRemote.isSelected)
                Configuration.setProperty(Configuration.HOST, host.text)
                Configuration.setProperty(Configuration.REDEEMED, redeemed.isSelected)
                Configuration.setProperty(Configuration.DUPLICATED, duplicated.isSelected)
                Configuration.setProperty(Configuration.INVALID, invalid.isSelected)
                Configuration.setProperty(Configuration.OWNED, owned.isSelected)
                Configuration.setProperty(Configuration.COOLDOWN, cooldown.isSelected)
                status.text = "Settings saved."
                status.textFill = c(0, 0, 0)
                status.fade(Duration.seconds(1.0), 1.0).setOnFinished {
                    val pause = PauseTransition(Duration.seconds(1.25))
                    pause.setOnFinished {
                        status.fade(Duration.seconds(1.0), 0.0)
                    }
                    pause.play()
                }
            }
        }

        isRemote.selectedProperty().onChange {
            host.isDisable = !isRemote.isSelected
        }
    }

    private fun loadSettings() {
        pathBinary.text = Configuration.getPropertyString(Configuration.BINARY, Configuration.BINARY_DEFAULT)
        isLocal.isSelected = Configuration.getPropertyBoolean(Configuration.IS_LOCAL, Configuration.IS_LOCAL_DEFAULT)
        isRemote.isSelected = Configuration.getPropertyBoolean(Configuration.IS_REMOTE, Configuration.IS_REMOTE_DEFAULT)
        host.text = Configuration.getPropertyString(Configuration.HOST, Configuration.HOST_DEFAULT)
        redeemed.isSelected = Configuration.getPropertyBoolean(Configuration.REDEEMED, Configuration.REDEEMED_DEFAULT)
        duplicated.isSelected = Configuration.getPropertyBoolean(Configuration.REDEEMED, Configuration.DUPLICATED_DEFAULT)
        invalid.isSelected = Configuration.getPropertyBoolean(Configuration.INVALID, Configuration.INVALID_DEFAULT)
        owned.isSelected = Configuration.getPropertyBoolean(Configuration.OWNED, Configuration.OWNED_DEFAULT)
        cooldown.isSelected = Configuration.getPropertyBoolean(Configuration.COOLDOWN, Configuration.COOLDOWN_DEFAULT)
    }

    private fun checkRemote(): Boolean {
        try {
            val check = khttp.get(host.text)
            return check.statusCode == 405
        } catch (e: Exception) {
            return false
        }
    }
}