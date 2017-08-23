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

class Blacklist : Fragment() {
    override val root: Parent by fxml("/blacklist.fxml")

    private val blacklistListButton: Button by fxid("blacklist_list")
    private val blacklistAddButton: Button by fxid("blacklist_add")
    private val blacklistRemoveButton: Button by fxid("blacklist_remove")

    private val input: TextArea by param()
    private val bots: ComboBox<String> by param()
    private var bot = bots.selectedItem

    init {
        bots.valueProperty().addListener { _, _, newBot ->
            bot = newBot
        }

        blacklistListButton.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.BLACKLIST, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        blacklistAddButton.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.BLACKLIST_ADD, bot, input.text.multiToOne()))
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }

        blacklistRemoveButton.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.BLACKLIST_REMOVE, bot, input.text.multiToOne()))
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }
    }
}