package me.alvr.asfui.views

import javafx.scene.Parent
import javafx.scene.control.Button
import javafx.scene.control.ComboBox
import javafx.scene.control.TextArea
import me.alvr.asfui.ASFProcess
import me.alvr.asfui.Command
import me.alvr.asfui.multiToOne
import tornadofx.Fragment
import tornadofx.action
import tornadofx.enableWhen

class License : Fragment() {
    override val root: Parent by fxml("/license.fxml")

    private val licenseAddButton: Button by fxid("license_add")
    private val licenseAddAllButton: Button by fxid("license_addall")

    private val input = params["input"] as TextArea
    private val bot = params["bot"] as String
    private val bots = params["bots"] as ComboBox<*>

    init {
        licenseAddButton.apply {
            action {
                runAsync {
                    val command = Command.generateCommand(Command.LICENSE, bot, input.text.multiToOne())
                    Command.sendCommand(command)
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }

        licenseAddAllButton.apply {
            action {
                runAsync {
                    bots.items.forEach {
                        val command = Command.generateCommand(Command.LICENSE, it as String, input.text.multiToOne())
                        Command.sendCommand(command)
                    }
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }
    }
}