package me.alvr.asfui.views

import javafx.scene.Parent
import javafx.scene.control.Button
import javafx.scene.control.ComboBox
import me.alvr.asfui.ASFProcess
import me.alvr.asfui.util.Command
import tornadofx.Fragment
import tornadofx.action
import tornadofx.enableWhen
import tornadofx.selectedItem

class TwoFA : Fragment() {
    override val root: Parent by fxml("/2fa.fxml")

    private val twoFAGenerateButton: Button by fxid("twofa_generate")
    private val twoFAAcceptButton: Button by fxid("twofa_accept")
    private val twoFADenyButton: Button by fxid("twofa_deny")

    private val bots: ComboBox<String> by param()
    private var bot = bots.selectedItem

    init {
        bots.valueProperty().addListener { _, _, newBot ->
            bot = newBot
        }

        twoFAGenerateButton.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.TWOFA, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        twoFAAcceptButton.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.TWOFA_ACCEPT, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        twoFADenyButton.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.TWOFA_DENY, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }
    }
}