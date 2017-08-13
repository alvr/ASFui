package me.alvr.asfui

object Command {
    private val basePath = Configuration.getPropertyString(Configuration.HOST, Configuration.HOST_DEFAULT)

    val REDEEM = "r"
    val REDEEM_MODE = "r^"
    val STATUS_ALL = "sa"
    val OWNS_ALL = "oa"

    fun sendCommand(command: String): String {
        val parameters = mapOf("command" to command)
        var response: String

        try {
            response = khttp.get("$basePath/IPC", params = parameters).text
        } catch (e: Exception) {
            response = "Error sending command. ArchiSteamFarm may be not running."
        }

        if (response.indexOf("</head><body><p>") != -1)
            return response.after("</head><body><p>").before("</p></body></html>").trim()

        return response.trim()
    }

    fun generateCommand(command: String, user: String, args: String = "") = "$command $user $args"

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