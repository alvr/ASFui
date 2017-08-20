package me.alvr.asfui.views

import javafx.scene.Parent
import javafx.scene.control.Button
import javafx.scene.control.ComboBox
import me.alvr.asfui.ASFProcess
import me.alvr.asfui.Command
import tornadofx.Fragment
import tornadofx.action
import tornadofx.enableWhen
import tornadofx.selectedItem

class Cards : Fragment() {
    override val root: Parent by fxml("/cards.fxml")

    private val cardsFarmButton: Button by fxid("cards_farm")
    private val cardsLootButton: Button by fxid("cards_loot")
    private val cardsLootAllButton: Button by fxid("cards_lootall")
    private val cardsUnpackButton: Button by fxid("cards_unpack")

    private val bots: ComboBox<String> by param()
    private var bot = bots.selectedItem!!

    init {
        bots.valueProperty().addListener { _, _, newBot ->
            bot = newBot
        }

        cardsFarmButton.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.FARM, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        cardsLootButton.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.LOOT, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        cardsLootAllButton.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.LOOT_ALL, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        cardsUnpackButton.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.UNPACK, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }
    }
}