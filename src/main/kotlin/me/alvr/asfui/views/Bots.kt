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

class Bots : Fragment() {
    override val root: Parent by fxml("/bots.fxml")

    private val botsStart: Button by fxid("bots_start")
    private val botsStartAll: Button by fxid("bots_startall")
    private val botsStop: Button by fxid("bots_stop")
    private val botsPause: Button by fxid("bots_pause")
    private val botsResume: Button by fxid("bots_resume")
    private val botsPassword: Button by fxid("bots_password")
    private val botsStatus: Button by fxid("bots_status")
    private val botsStatusAll: Button by fxid("bots_statusall")

    private val bots: ComboBox<String> by param()
    private var bot = bots.selectedItem!!

    init {
        bots.valueProperty().addListener { _, _, newBot ->
            bot = newBot
        }

        botsStart.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.START, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        botsStartAll.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.START_ALL)
                }
            }
            enableWhen(ASFProcess.started)
        }

        botsStop.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.STOP, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        botsPause.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.PAUSE, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        botsResume.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.RESUME, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        botsPassword.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.PASSWORD, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        botsStatus.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.STATUS, bot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        botsStatusAll.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.STATUS_ALL)
                }
            }
            enableWhen(ASFProcess.started)
        }
    }
}