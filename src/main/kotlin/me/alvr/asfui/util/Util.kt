package me.alvr.asfui.util

import java.util.Properties

fun String.multiToOne(): String = this
        .replace("\r\n", "\n")
        .replace("\r", "\n")
        .split("\n")
        .map {
            it.trim()
        }
        .filterNot {
            it == ""
        }.joinToString(",")

fun updateAvailable(): Boolean {
    val gitVersion = khttp.get("https://raw.githubusercontent.com/alvr/ASFui/master/version.txt", timeout = 10.0).text
    return gitVersion > getCurrentVersion()
}

fun getCurrentVersion(): String {
    val props = Properties().apply {
        ClassLoader.getSystemResource("version.properties").openStream().use { f ->
            load(f)
        }
    }

    return props.getProperty("version")
}

fun checkRemote(url: String): Boolean = try {
    val check = khttp.get(url)
    check.statusCode == 405
} catch (e: Exception) {
    false
}