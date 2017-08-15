package me.alvr.asfui

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

fun updateAvailable(): Boolean = try {
    val gitVersion = khttp.get("https://raw.githubusercontent.com/alvr/ASFui/master/version.txt", timeout = 10.0).text

    val props = Properties().apply {
        ClassLoader.getSystemResource("version.properties").openStream().use { f ->
            load(f)
        }
    }

    gitVersion > props.getProperty("version")
} catch (e: Exception) {
    false
}