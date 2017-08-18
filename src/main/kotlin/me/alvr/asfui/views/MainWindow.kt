package me.alvr.asfui.views

import javafx.application.Platform
import javafx.scene.control.Alert.AlertType.CONFIRMATION
import javafx.scene.control.Button
import javafx.scene.control.ButtonType
import javafx.scene.control.ComboBox
import javafx.scene.control.TextArea
import javafx.scene.control.TextInputDialog
import javafx.scene.effect.DropShadow
import javafx.scene.layout.AnchorPane
import javafx.stage.StageStyle.UTILITY
import me.alvr.asfui.ASFProcess
import me.alvr.asfui.updateAvailable
import me.alvr.asfui.util.ConfigValues
import me.alvr.asfui.util.OpenBrowser
import org.apache.commons.io.FileUtils
import org.apache.commons.io.FilenameUtils
import org.apache.commons.io.filefilter.WildcardFileFilter
import tornadofx.View
import tornadofx.action
import tornadofx.alert
import tornadofx.c
import tornadofx.confirm
import tornadofx.enableWhen
import tornadofx.getLong
import tornadofx.loadJsonObject
import tornadofx.replaceChildren
import tornadofx.runLater
import tornadofx.save
import tornadofx.toProperty
import java.io.File
import java.nio.file.Path
import java.nio.file.Paths
import javax.json.Json
import javax.json.JsonObject
import javax.json.JsonObjectBuilder

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

    // Control
    private val botsButton: Button by fxid("bots")
    private val redeemButton: Button by fxid("redeem")
    private val licensesButton: Button by fxid("licenses")
    private val cardsButton: Button by fxid("cards")
    private val gamesButton: Button by fxid("games")

    private val container: AnchorPane by fxid("container")

    init {
        if (updateAvailable()) {
            confirm("Update found", "A new version is available, download now?", actionFn = {
                openBrowser.openUrl("https://github.com/alvr/ASFui/releases/latest")
            })
        }

        // Main
        startButton.apply {
            action {
                checkValidConfig()
                output.appendText("Starting ASF...\n")
                runAsync {
                    ASFProcess.start(output)
                    loadBots()
                }
            }
            enableWhen(!ASFProcess.started.and(config.string(ConfigValues.BINARY).toProperty().isNotEmpty))
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

        botsButton.apply {
            action {
                container.replaceChildren(find(Bots::class, mapOf("bot" to selectedBot)))
            }
            enableWhen(ASFProcess.started)
        }

        redeemButton.apply {
            action {
                container.replaceChildren(find(Redeem::class, mapOf("input" to input, "bot" to selectedBot)))
            }
            enableWhen(ASFProcess.started)
        }

        licensesButton.apply {
            action {
                container.replaceChildren(find(License::class, mapOf("input" to input, "bot" to selectedBot, "bots" to bots)))
            }
            enableWhen(ASFProcess.started)
        }

        cardsButton.apply {
            action {
                container.replaceChildren(find(Cards::class, mapOf("bot" to selectedBot)))
            }
            enableWhen(ASFProcess.started)
        }

        gamesButton.apply {
            action {
                container.replaceChildren(find(Games::class, mapOf("input" to input, "bot" to selectedBot)))
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

    private fun checkValidConfig() {
        if (config.boolean("islocal")) {
            val configDir = File(File(config.string(ConfigValues.BINARY)).parent + File.separator + "config" + File.separator)
            val config = Paths.get(configDir.absolutePath + File.separator + "ASF.json")
            var json = loadJsonObject(config)

            var showMessage = false
            var message = "The following parameter(s) will be changed automatically. Abort to change them manually.\n\n"
            if (json.isNull("CurrentCulture") || json.getString("CurrentCulture") != "en") {
                val cc = if (json.isNull("CurrentCulture")) "null" else json.getString("CurrentCulture")
                message += "• CurrentCulture is: $cc, will be: en\n"
                json = updateJson(json).add("CurrentCulture", "en").build()
                showMessage = true
            }

            if (json.getBoolean("AutoRestart")) {
                message += "• AutoRestart is: ${json.getBoolean("AutoRestart")}, will be: false\n"
                json = updateJson(json).add("AutoRestart", false).build()
                showMessage = true
            }

            if (json.getLong("SteamOwnerID") == 0L) {
                val dialog = TextInputDialog()
                dialog.title = "Enter necessary input."
                dialog.headerText = "SteamOwnerID is set to ${json.getLong("SteamOwnerID")}.\n" +
                        "It should be the Steam64ID of your primary account.\n" +
                        "Go to http://steamid.co if you don't know yours."
                val result = dialog.showAndWait()
                if (result.isPresent) {
                    try {
                        message += "• SteamOwnerID is 0, will be ${result.get()}\n"
                        json = updateJson(json).add("SteamOwnerID", result.get().toLong()).build()
                        showMessage = true
                    } catch (e: Exception) {
                        tornadofx.error("Error", e.message)
                    }
                }
            }

            if (showMessage) {
                alert(CONFIRMATION, "Config needs to be changed.", message, ButtonType.OK, ButtonType.CANCEL) {
                    when (it) {
                        ButtonType.OK -> {
                            json.save(config)
                        }
                        ButtonType.CANCEL -> Platform.exit()
                    }
                }
            }
        }
    }

    private fun updateJson(json: JsonObject): JsonObjectBuilder {
        val job = Json.createObjectBuilder()
        json.forEach { key, value -> job.add(key, value) }
        return job
    }

    private val selectedBot get() = bots.selectionModel.selectedItem
}