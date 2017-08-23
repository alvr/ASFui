package me.alvr.asfui.views

import javafx.scene.Parent
import javafx.scene.control.Button
import javafx.scene.control.ComboBox
import javafx.scene.control.TextArea
import me.alvr.asfui.ASFProcess
import me.alvr.asfui.util.Command
import me.alvr.asfui.util.multiToOne
import tornadofx.Fragment
import tornadofx.action
import tornadofx.enableWhen
import tornadofx.selectedItem

class Idling : Fragment() {
    override val root: Parent by fxml("/idling.fxml")

    private val idlingListButton: Button by fxid("idling_list")
    private val idlingAddButton: Button by fxid("idling_add")
    private val idlingRemoveButton: Button by fxid("idling_remove")

    private val input: TextArea by param()
    private val bots: ComboBox<String> by param()
    private var bot = bots.selectedItem

    init {
        bots.valueProperty().addListener { _, _, newBot ->
            bot = newBot
        }

        idlingListButton.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.IDLING, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        idlingAddButton.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.IDLING_ADD, bot, input.text.multiToOne()))
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }

        idlingRemoveButton.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.IDLING_REMOVE, bot, input.text.multiToOne()))
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }
    }
}