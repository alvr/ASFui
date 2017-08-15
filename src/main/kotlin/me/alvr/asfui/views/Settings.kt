package me.alvr.asfui.views

import java.nio.file.Path
import javafx.animation.PauseTransition
import javafx.scene.control.Button
import javafx.scene.control.CheckBox
import javafx.scene.control.Label
import javafx.scene.control.TextField
import javafx.scene.control.ToggleButton
import javafx.scene.layout.AnchorPane
import javafx.util.Duration
import me.alvr.asfui.util.ConfigValues
import tornadofx.action
import tornadofx.c
import tornadofx.chooseFile
import tornadofx.fade
import tornadofx.onChange
import tornadofx.View

class Settings : View("Settings") {
    override val root: AnchorPane by fxml("/settings.fxml")
    override val configPath: Path = app.configBasePath.resolve("asfui.properties")

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
            val binary = chooseFile("Select ASF binary", emptyArray()).firstOrNull()
            binary?.let {
                pathBinary.text = binary.path
            }
        }

        save.action {
            if (isRemote.isSelected && !checkRemote()) {
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
                with(config) {
                    set(ConfigValues.BINARY to pathBinary.text)
                    set(ConfigValues.IS_LOCAL to isLocal.isSelected)
                    set(ConfigValues.IS_REMOTE to isRemote.isSelected)
                    set(ConfigValues.HOST to host.text)
                    set(ConfigValues.REDEEMED to redeemed.isSelected)
                    set(ConfigValues.DUPLICATED to duplicated.isSelected)
                    set(ConfigValues.INVALID to invalid.isSelected)
                    set(ConfigValues.OWNED to owned.isSelected)
                    set(ConfigValues.COOLDOWN to cooldown.isSelected)
                    save()
                }
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
        with(config) {
            pathBinary.text = string(ConfigValues.BINARY)
            isLocal.isSelected = boolean(ConfigValues.IS_LOCAL)
            isRemote.isSelected = boolean(ConfigValues.IS_REMOTE)
            host.text = string(ConfigValues.HOST, ConfigValues.HOST_DEFAULT)
            redeemed.isSelected = boolean(ConfigValues.REDEEMED)
            duplicated.isSelected = boolean(ConfigValues.REDEEMED)
            invalid.isSelected = boolean(ConfigValues.INVALID)
            owned.isSelected = boolean(ConfigValues.OWNED)
            cooldown.isSelected = boolean(ConfigValues.COOLDOWN)
        }
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