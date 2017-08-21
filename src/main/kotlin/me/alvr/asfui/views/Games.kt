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
import tornadofx.selectedItem

class Games : Fragment() {
    override val root: Parent by fxml("/games.fxml")

    private val gamesOwnButton: Button by fxid("games_own")
    private val gamesOwnAllButton: Button by fxid("games_ownall")
    private val gamesPlayButton: Button by fxid("games_play")

    private val input: TextArea by param()
    private val bots: ComboBox<String> by param()
    private var bot = bots.selectedItem

    init {
        bots.valueProperty().addListener { _, _, newBot ->
            bot = newBot
        }

        gamesOwnButton.apply {
            action {
                runAsync {
                    val command = Command.generateCommand(Command.OWN, bot, input.text.multiToOne())
                    Command.sendCommand(command)
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }

        gamesOwnAllButton.apply {
            action {
                runAsync {
                    val command = Command.generateCommand(Command.OWN_ALL, "", input.text.multiToOne())
                    Command.sendCommand(command)
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }

        gamesPlayButton.apply {
            action {
                runAsync {
                    val command = Command.generateCommand(Command.PLAY, bot, input.text.multiToOne())
                    Command.sendCommand(command)
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }
    }
}