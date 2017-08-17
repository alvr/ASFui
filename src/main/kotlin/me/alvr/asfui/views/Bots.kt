package me.alvr.asfui.views

import javafx.scene.Parent
import javafx.scene.control.Button
import me.alvr.asfui.ASFProcess
import me.alvr.asfui.Command
import tornadofx.Fragment
import tornadofx.action
import tornadofx.enableWhen
import tornadofx.runLater

class Bots : Fragment() {
    override val root: Parent by fxml("/bots.fxml")

    private val botsStart: Button by fxid("bots_start")
    private val botsStop: Button by fxid("bots_stop")

    private val bot = params["bot"] as String
    
    init {
        botsStart.apply {
            action {
                runLater {
                    Command.sendCommand(Command.generateCommand(Command.START, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        botsStop.apply {
            action {
                runLater {
                    Command.sendCommand(Command.generateCommand(Command.STOP, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }
    }
}