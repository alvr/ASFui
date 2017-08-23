package me.alvr.asfui.util

import tornadofx.Controller

object Command : Controller() {
    private val basePath = config.getProperty(ConfigValues.HOST, ConfigValues.HOST_DEFAULT)

    // Redeem
    const val REDEEM = "r"
    const val REDEEM_MODE = "r^"

    // License
    const val LICENSE = "addlicense"

    // Cards
    const val FARM = "farm"
    const val LOOT = "loot"
    const val LOOT_ALL = "loot ASF"
    const val UNPACK = "unpack"

    // Games
    const val OWN = "owns"
    const val OWN_ALL = "oa"
    const val PLAY = "play"

    // Bots
    const val START = "start"
    const val START_ALL = "start ASF"
    const val STOP = "stop"
    const val PAUSE = "pause"
    const val RESUME = "resume"
    const val PASSWORD = "password"
    const val STATUS = "status"
    const val STATUS_ALL = "sa"

    // ArchiSteamFarm
    const val REJOIN_CHAT = "rejoinchat"
    const val UPDATE = "update"
    const val VERSION = "version"
    const val API = "api"

    // 2FA
    const val TWOFA = "2fa"
    const val TWOFA_ACCEPT = "2faok"
    const val TWOFA_DENY = "2fano"

    fun sendCommand(command: String): String {
        val parameters = mapOf("command" to command)

        val response = try {
            khttp.get("$basePath/IPC", params = parameters).text
        } catch (e: Exception) {
            "Error sending command. ArchiSteamFarm may be not running."
        }

        if (response.indexOf("</head><body><p>") != -1)
            return response.after("</head><body><p>").before("</p></body></html>").trim()

        return response.trim()
    }

    fun generateCommand(command: String, user: String?, args: String = "", pre: String = "") = "$command $user $pre $args"

    private fun String.after(find: String): String {
        val index = this.indexOf(find)
        return when {
            index < 0 || index + find.length >= this.length -> ""
            else -> this.substring(index + find.length)
        }
    }

    private fun String.before(find: String): String {
        val index = this.lastIndexOf(find)
        return when {
            index >= 0 -> this.substring(0, index)
            else -> ""
        }
    }
}