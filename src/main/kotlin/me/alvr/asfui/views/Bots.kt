package me.alvr.asfui.views

import javafx.scene.Parent
import javafx.scene.control.Button
import me.alvr.asfui.ASFProcess
import me.alvr.asfui.Command
import tornadofx.Fragment
import tornadofx.action
import tornadofx.enableWhen

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

    private val bot = params["bot"] as String
    
    init {
        botsStart.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.START, bot.botName.value))
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
                    Command.sendCommand(Command.generateCommand(Command.STOP, bot.botName.value))
                }
            }
            enableWhen(ASFProcess.started)
        }

        botsPause.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.PAUSE, bot.botName.value))
                }
            }
            enableWhen(ASFProcess.started)
        }

        botsResume.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.RESUME, bot.botName.value))
                }
            }
            enableWhen(ASFProcess.started)
        }

        botsPassword.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.PASSWORD, bot.botName.value))
                }
            }
            enableWhen(ASFProcess.started)
        }

        botsStatus.apply {
            action {
                runAsync {
                    Command.sendCommand(Command.generateCommand(Command.STATUS, bot.botName.value))
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