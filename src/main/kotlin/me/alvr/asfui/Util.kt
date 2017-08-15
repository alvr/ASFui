package me.alvr.asfui

import java.io.File
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
    try {
        val gitVersion = khttp.get("https://raw.githubusercontent.com/alvr/ASFui/master/version.txt", timeout = 10.0).text

        val props = Properties()
        File("src/main/resources/version.properties").inputStream().use { f ->
            props.load(f)
        }

        return props.getProperty("version") >= gitVersion
    } catch (e: Exception) {
        return false
    }
}