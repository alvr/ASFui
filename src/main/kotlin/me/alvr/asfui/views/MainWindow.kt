package me.alvr.asfui.views

import javafx.application.Platform
import javafx.beans.property.SimpleBooleanProperty
import javafx.scene.control.Alert.AlertType.CONFIRMATION
import javafx.scene.control.Button
import javafx.scene.control.ButtonType
import javafx.scene.control.ComboBox
import javafx.scene.control.TextArea
import javafx.scene.control.TextInputDialog
import javafx.scene.layout.AnchorPane
import javafx.scene.layout.Pane
import javafx.stage.FileChooser
import javafx.stage.StageStyle.UTILITY
import javafx.util.Duration
import me.alvr.asfui.ASFProcess
import me.alvr.asfui.util.ConfigManager
import me.alvr.asfui.util.ConfigValues
import me.alvr.asfui.util.checkRemote
import me.alvr.asfui.util.getCurrentVersion
import me.alvr.asfui.util.updateAvailable
import org.apache.commons.io.FileUtils
import org.apache.commons.io.FilenameUtils
import org.apache.commons.io.filefilter.WildcardFileFilter
import org.controlsfx.glyphfont.FontAwesome
import org.controlsfx.glyphfont.GlyphFont
import org.controlsfx.glyphfont.GlyphFontRegistry
import tornadofx.View
import tornadofx.action
import tornadofx.alert
import tornadofx.chooseFile
import tornadofx.confirm
import tornadofx.enableWhen
import tornadofx.error
import tornadofx.getLong
import tornadofx.loadJsonObject
import tornadofx.property
import tornadofx.replaceChildren
import tornadofx.runLater
import tornadofx.toPrettyString
import java.io.File
import java.nio.charset.Charset
import java.nio.file.Paths
import javax.json.Json
import javax.json.JsonObject
import javax.json.JsonObjectBuilder

class MainWindow : View("ASFui v${getCurrentVersion()}") {
    override val root: AnchorPane by fxml("/main.fxml")

    // Main
    private val startButton: Button by fxid("start")
    private val stopButton: Button by fxid("stop")
    private val clearButton: Button by fxid("clear")
    private val output: TextArea by fxid("output")
    private val input: TextArea by fxid("input")
    private val loadInputButton: Button by fxid("load_input")
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
    private val asfButton: Button by fxid("asf")
    private val twoFAButton: Button by fxid("twofa")
    private val blacklistButton: Button by fxid("blacklist")
    private val idlingButton: Button by fxid("idling")

    private val container: Pane by fxid("container")
    private val fontAwesome: GlyphFont = GlyphFontRegistry.font("FontAwesome")

    companion object {
        private val isBinarySelectedProperty = SimpleBooleanProperty(!ConfigManager.string(ConfigValues.BINARY).isEmpty())
        var isBinarySelected: SimpleBooleanProperty by property(isBinarySelectedProperty)
    }

    init {
        if (updateAvailable()) {
            confirm("Update found", "A new version is available, download now?", actionFn = {
                hostServices.showDocument("https://github.com/alvr/ASFui/releases/latest")
            })
        }

        if (ConfigManager.boolean(ConfigValues.AUTO_START)) {
            checkValidConfig()
            runLater(Duration(1000.0)) {
                ASFProcess.input = input
                ASFProcess.output = output
                ASFProcess.start()
                loadBots()
            }
        }

        // Main
        startButton.apply {
            action {
                checkValidConfig()
                output.appendText("Starting ASF...\n")
                runLater {
                    ASFProcess.input = input
                    ASFProcess.output = output
                    ASFProcess.start()
                    loadBots()
                }
            }
            enableWhen(ASFProcess.started.not().and(isBinarySelected))
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
            graphic = fontAwesome.create(FontAwesome.Glyph.REFRESH)
            action { loadBots() }
            enableWhen(ASFProcess.started)
        }

        settings.apply {
            graphic = fontAwesome.create(FontAwesome.Glyph.COG)
            action { find(Settings::class).openModal(block = true, stageStyle = UTILITY) }
        }

        help.apply {
            graphic = fontAwesome.create(FontAwesome.Glyph.QUESTION)
            action {
                hostServices.showDocument("https://github.com/alvr/ASFui/wiki")
            }
        }

        loadInputButton.apply {
            action {
                val file = chooseFile("Choose file to load", arrayOf(FileChooser.ExtensionFilter("TXT files (*.txt)", "*.txt"))).firstOrNull()
                file?.let {
                    input.text = file.readText()
                }
            }
            enableWhen(ASFProcess.started)
        }

        botsButton.apply {
            action {
                container.replaceChildren(find(Bots::class, mapOf("bots" to bots)))
            }
            enableWhen(ASFProcess.started)
        }

        redeemButton.apply {
            action {
                container.replaceChildren(find(Redeem::class, mapOf("input" to input, "bots" to bots)))
            }
            enableWhen(ASFProcess.started)
        }

        licensesButton.apply {
            action {
                container.replaceChildren(find(License::class, mapOf("input" to input, "bots" to bots)))
            }
            enableWhen(ASFProcess.started)
        }

        cardsButton.apply {
            action {
                container.replaceChildren(find(Cards::class, mapOf("bots" to bots)))
            }
            enableWhen(ASFProcess.started)
        }

        gamesButton.apply {
            action {
                container.replaceChildren(find(Games::class, mapOf("input" to input, "bots" to bots)))
            }
            enableWhen(ASFProcess.started)
        }

        asfButton.apply {
            action {
                container.replaceChildren(find(ASF::class, mapOf("input" to input, "bots" to bots)))
            }
            enableWhen(ASFProcess.started)
        }

        twoFAButton.apply {
            action {
                container.replaceChildren(find(TwoFA::class, mapOf("bots" to bots)))
            }
            enableWhen(ASFProcess.started)
        }

        blacklistButton.apply {
            action {
                container.replaceChildren(find(Blacklist::class, mapOf("input" to input, "bots" to bots)))
            }
            enableWhen(ASFProcess.started)
        }

        idlingButton.apply {
            action {
                container.replaceChildren(find(Idling::class, mapOf("input" to input, "bots" to bots)))
            }
            enableWhen(ASFProcess.started)
        }
    }

    private fun loadBots() = runLater {
        bots.apply {
            items.clear()

            val configDir = File(File(ConfigManager.string(ConfigValues.BINARY)).parent + File.separator + "config" + File.separator)
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
        if (ConfigManager.boolean("islocal")) {
            val configDir = File(File(ConfigManager.string(ConfigValues.BINARY)).parent + File.separator + "config" + File.separator)
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
                        error("Error", e.message)
                    }
                }
            }

            if (showMessage) {
                alert(CONFIRMATION, "Config needs to be changed.", message, ButtonType.OK, ButtonType.CANCEL) {
                    when (it) {
                        ButtonType.OK -> FileUtils.writeStringToFile(config.toFile(), json.toPrettyString(), Charset.defaultCharset())
                        ButtonType.CANCEL -> Platform.exit()
                    }
                }
            }
        } else {
            if (!checkRemote(ConfigManager.string("host"))) {
                error("Cannot connect to remote")
                return
            }
        }
    }

    private fun updateJson(json: JsonObject): JsonObjectBuilder {
        val job = Json.createObjectBuilder()
        json.forEach { key, value -> job.add(key, value) }
        return job
    }
}