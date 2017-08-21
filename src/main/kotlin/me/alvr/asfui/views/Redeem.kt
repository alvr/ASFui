package me.alvr.asfui.views

import javafx.scene.Parent
import javafx.scene.control.Button
import javafx.scene.control.CheckMenuItem
import javafx.scene.control.ComboBox
import javafx.scene.control.SplitMenuButton
import javafx.scene.control.TextArea
import me.alvr.asfui.ASFProcess
import me.alvr.asfui.Command
import me.alvr.asfui.multiToOne
import tornadofx.Fragment
import tornadofx.action
import tornadofx.enableWhen
import tornadofx.selectedItem

class Redeem : Fragment() {
    override val root: Parent by fxml("/redeem.fxml")

    private val redeemButton: Button by fxid("redeem_normal")
    private val redeemModeButton: SplitMenuButton by fxid("redeem_mode")

    private val input: TextArea by param()
    private val bots: ComboBox<String> by param()
    private var bot = bots.selectedItem

    init {
        bots.valueProperty().addListener { _, _, newBot ->
            bot = newBot
        }

        redeemButton.apply {
            action {
                runAsync {
                    val command = Command.generateCommand(Command.REDEEM, bot, input.text.multiToOne())
                    Command.sendCommand(command)
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }

        redeemModeButton.apply {
            action {
                val methods = redeemModeButton.items.map {
                    it as CheckMenuItem
                }.filter {
                    it.isSelected
                }.map {
                    it.userData
                }.joinToString(",")

                val command = Command.generateCommand(Command.REDEEM_MODE, bot, input.text.multiToOne(), methods)
                Command.sendCommand(command)
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }
    }
}