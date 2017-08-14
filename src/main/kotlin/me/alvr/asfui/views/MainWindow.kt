package me.alvr.asfui.views

import javafx.scene.control.Button
import javafx.scene.control.CheckMenuItem
import javafx.scene.control.ComboBox
import javafx.scene.control.TextArea
import javafx.scene.layout.AnchorPane
import javafx.stage.StageStyle.UTILITY
import me.alvr.asfui.ASFProcess
import me.alvr.asfui.Configuration
import me.alvr.asfui.util.OpenBrowser
import org.apache.commons.io.FileUtils
import org.apache.commons.io.FilenameUtils
import org.apache.commons.io.filefilter.WildcardFileFilter
import tornadofx.*
import java.io.File

class MainWindow : View("ASFui") {
    override val root: AnchorPane by fxml("/main.fxml")
    val openBrowser: OpenBrowser by inject()

    // Main
    val startButton: Button by fxid("start")
    val stopButton: Button by fxid("stop")
    val clearButton: Button by fxid("clear")
    val output: TextArea by fxid("output")
    val input: TextArea by fxid("input")
    val bots: ComboBox<String> by fxid("list_bot")
    val reloadBots: Button by fxid("reload_bots")
    val settings: Button by fxid("settings")
    val help: Button by fxid("help")

    // Redeem
    val redeemButton: Button by fxid("redeem_normal")
    val redeemModeButton: Button by fxid("redeem_mode")
    val redeemFDButton: CheckMenuItem by fxid("redeem_fd")
    val redeemFFButton: CheckMenuItem by fxid("redeem_ff")
    val redeemFKMGButton: CheckMenuItem by fxid("redeem_fkmg")
    val redeemSDButton: CheckMenuItem by fxid("redeem_sd")
    val redeemSFButton: CheckMenuItem by fxid("redeem_sf")
    val redeemSIButton: CheckMenuItem by fxid("redeem_si")
    val redeemSKMGButton: CheckMenuItem by fxid("redeem_skmg")

    // License
    val licenseAddButton: Button by fxid("license_add")
    val licenseAddAllButton: Button by fxid("license_addall")

    // Cards
    val cardsFarmButton: Button by fxid("cards_farm")
    val cardsLootButton: Button by fxid("cards_loot")
    val cardsLootAllButton: Button by fxid("cards_lootall")
    val cardsUnpackButton: Button by fxid("cards_unpack")

    init {
        while (Configuration.getPropertyString(Configuration.BINARY, Configuration.BINARY_DEFAULT) == "") {
            find(Settings::class).openModal(block = true, stageStyle = UTILITY)
        }

        // Main
        startButton.action {
            output.appendText("Starting ASF...\n")
            runAsync {
                ASFProcess.start(output)
                loadBots()
            }
        }

        stopButton.action {
            output.appendText("Stopping ASF...\n")
            ASFProcess.stop()
        }

        clearButton.action {
            output.clear()
        }

        reloadBots.action {
            loadBots()
        }

        settings.action {
            find(Settings::class).openModal(block = true, stageStyle = UTILITY)
        }

        help.action {
            openBrowser.openUrl("https://github.com/alvr/ASFui/wiki")
        }

        }
    }

    private fun loadBots() = runLater {
        bots.apply {
            items.clear()
            
            val configDir = File(File(Configuration.getPropertyString(Configuration.BINARY, Configuration.BINARY_DEFAULT)).parent + File.separator + "config" + File.separator)
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
}