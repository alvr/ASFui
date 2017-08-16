package me.alvr.asfui.views

import javafx.scene.control.Button
import javafx.scene.control.CheckMenuItem
import javafx.scene.control.ComboBox
import javafx.scene.control.SplitMenuButton
import javafx.scene.control.TextArea
import javafx.scene.effect.DropShadow
import javafx.scene.layout.AnchorPane
import javafx.stage.StageStyle.UTILITY
import me.alvr.asfui.ASFProcess
import me.alvr.asfui.Command
import me.alvr.asfui.multiToOne
import me.alvr.asfui.updateAvailable
import me.alvr.asfui.util.ConfigValues
import me.alvr.asfui.util.OpenBrowser
import org.apache.commons.io.FileUtils
import org.apache.commons.io.FilenameUtils
import org.apache.commons.io.filefilter.WildcardFileFilter
import tornadofx.View
import tornadofx.action
import tornadofx.c
import tornadofx.confirm
import tornadofx.enableWhen
import tornadofx.runLater
import tornadofx.toProperty
import java.io.File
import java.nio.file.Path

class MainWindow : View("ASFui") {
    override val root: AnchorPane by fxml("/main.fxml")
    override val configPath: Path = app.configBasePath.resolve("asfui.properties")
    private val openBrowser: OpenBrowser by inject()

    // Main
    private val startButton: Button by fxid("start")
    private val stopButton: Button by fxid("stop")
    private val clearButton: Button by fxid("clear")
    private val output: TextArea by fxid("output")
    private val input: TextArea by fxid("input")
    private val bots: ComboBox<String> by fxid("list_bot")
    private val reloadBots: Button by fxid("reload_bots")
    private val settings: Button by fxid("settings")
    private val help: Button by fxid("help")

    // Redeem
    private val redeemButton: Button by fxid("redeem_normal")
    private val redeemModeButton: SplitMenuButton by fxid("redeem_mode")

    // License
    private val licenseAddButton: Button by fxid("license_add")
    private val licenseAddAllButton: Button by fxid("license_addall")

    // Cards
    private val cardsFarmButton: Button by fxid("cards_farm")
    private val cardsLootButton: Button by fxid("cards_loot")
    private val cardsLootAllButton: Button by fxid("cards_lootall")
    private val cardsUnpackButton: Button by fxid("cards_unpack")

    // Games
    private val gamesOwnButton: Button by fxid("games_own")
    private val gamesOwnAllButton: Button by fxid("games_ownall")
    private val gamesPlayButton: Button by fxid("games_play")

    // Bots
    private val botsStart: Button by fxid("bots_start")
    private val botsStop: Button by fxid("bots_stop")

    init {
        if (updateAvailable()) {
            confirm("Update found", "A new version is available, download now?", actionFn = {
                openBrowser.openUrl("https://github.com/alvr/ASFui/releases/latest")
            })
        }

        // Main
        startButton.apply {
            action {
                output.appendText("Starting ASF...\n")
                runAsync {
                    ASFProcess.start(output)
                    loadBots()
                }
            }
            enableWhen(!ASFProcess.started.and((config.string(ConfigValues.BINARY).toProperty().isEmpty)
                    .or(config.string(ConfigValues.BINARY).toProperty().isNull)))
        }

        stopButton.apply {
            action {
                output.appendText("Stopping ASF...\n")
                bots.items.clear()
                ASFProcess.stop()
            }
            enableWhen(ASFProcess.started)
        }

        clearButton.apply {
            action { output.clear() }
            enableWhen(ASFProcess.started)
        }

        bots.apply {
            enableWhen(ASFProcess.started)
        }

        reloadBots.apply {
            action { loadBots() }
            enableWhen(ASFProcess.started)
        }

        settings.apply {
            action {
                find(Settings::class).openModal(block = true, stageStyle = UTILITY)
            }

            if (config.string(ConfigValues.BINARY).isNullOrEmpty()) {
                effect = DropShadow().apply {
                    color = c(255, 0, 0)
                    spread = 0.8
                    height = 7.5
                    width = 7.5
                }
            }
        }

        help.action {
            openBrowser.openUrl("https://github.com/alvr/ASFui/wiki")
        }

        // Redeem
        redeemButton.apply {
            action {
                runLater {
                    val command = Command.generateCommand(Command.REDEEM, selectedBot, input.text.multiToOne())
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

                val command = Command.generateCommand(Command.REDEEM_MODE, selectedBot, input.text.multiToOne(), methods)
                Command.sendCommand(command)
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }

        // License
        licenseAddButton.apply {
            action {
                runLater {
                    val command = Command.generateCommand(Command.LICENSE, selectedBot, input.text.multiToOne())
                    Command.sendCommand(command)
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }

        licenseAddAllButton.apply {
            action {
                runLater {
                    bots.items.forEach {
                        val command = Command.generateCommand(Command.LICENSE, it, input.text.multiToOne())
                        Command.sendCommand(command)
                    }
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }

        // Cards
        cardsFarmButton.apply {
            action {
                runLater {
                    Command.sendCommand(Command.generateCommand(Command.FARM, selectedBot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        cardsLootButton.apply {
            action {
                runLater {
                    Command.sendCommand(Command.generateCommand(Command.LOOT, selectedBot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        cardsLootAllButton.apply {
            action {
                runLater {
                    Command.sendCommand(Command.generateCommand(Command.LOOT_ALL, selectedBot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        cardsUnpackButton.apply {
            action {
                runLater {
                    Command.sendCommand(Command.generateCommand(Command.UNPACK, selectedBot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        // Games
        gamesOwnButton.apply {
            action {
                runLater {
                    val command = Command.generateCommand(Command.OWN, selectedBot, input.text.multiToOne())
                    Command.sendCommand(command)
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }

        gamesOwnAllButton.apply {
            action {
                runLater {
                    val command = Command.generateCommand(Command.OWN, "ASF", input.text.multiToOne())
                    Command.sendCommand(command)
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }

        gamesPlayButton.apply {
            action {
                runLater {
                    val command = Command.generateCommand(Command.PLAY, selectedBot, input.text.multiToOne())
                    Command.sendCommand(command)
                }
            }
            enableWhen(ASFProcess.started.and(input.textProperty().isNotEmpty))
        }

        // Bots
        botsStart.apply {
            action {
                runLater {
                    Command.sendCommand(Command.generateCommand(Command.START, selectedBot))
                }
            }
            enableWhen(ASFProcess.started)
        }

        botsStop.apply {
            action {
                runLater {
                    Command.sendCommand(Command.generateCommand(Command.STOP, selectedBot))
                }
            }
            enableWhen(ASFProcess.started)
        }
    }

    private fun loadBots() = runLater {
        bots.apply {
            items.clear()

            val configDir = File(File(config.string(ConfigValues.BINARY)).parent + File.separator + "config" + File.separator)
            val botList = FileUtils.listFiles(configDir, WildcardFileFilter("*.json"), null)

            botList.filterNot {
                FilenameUtils.getBaseName((it as File).absolutePath) == "ASF"
                        || FilenameUtils.getBaseName((it).absolutePath) == "example"
                        || FilenameUtils.getBaseName((it).absolutePath) == "minimal"
            }.map {
                FilenameUtils.getBaseName((it as File).absolutePath)
            }.forEach {
                items.add(it)
            }

            selectionModel.selectFirst()
        }
    }

    private val selectedBot get() = bots.selectionModel.selectedItem
}