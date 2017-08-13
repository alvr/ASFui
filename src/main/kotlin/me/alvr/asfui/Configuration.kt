package me.alvr.asfui

import java.io.File
import java.util.Properties
import org.apache.commons.io.FileUtils

object Configuration {
    private val configFile = "asfui.properties"
    private val props = Properties()

    val BINARY = "binary"
    val BINARY_DEFAULT = ""

    val IS_LOCAL = "islocal"
    val IS_LOCAL_DEFAULT = true

    val IS_REMOTE = "isremote"
    val IS_REMOTE_DEFAULT = false

    val HOST = "host"
    val HOST_DEFAULT = "http://127.0.0.1:1242"

    val REDEEMED = "redeemed"
    val REDEEMED_DEFAULT = true

    val DUPLICATED = "duplicated"
    val DUPLICATED_DEFAULT = true

    val INVALID = "invalid"
    val INVALID_DEFAULT = false

    val OWNED = "owned"
    val OWNED_DEFAULT = false

    val COOLDOWN = "cooldown"
    val COOLDOWN_DEFAULT = false

    fun loadProperties() {
        if (!File(configFile).exists()) {
            val config = ClassLoader.getSystemResource("asfui.properties")
            FileUtils.copyURLToFile(config, File(configFile))
        }

        File(configFile).inputStream().use { f ->
            props.load(f)
        }
    }

    fun setProperty(property: String, value: Any, message: String = "Configuration saved.") {
        props.setProperty(property, value.toString())
        File(configFile).outputStream().use { f ->
            props.store(f, message)
        }
    }

    fun getPropertyString(property: String, default: String): String {
        return props.getProperty(property, default)
    }

    fun getPropertyInt(property: String, default: Int): Int {
        return props.getProperty(property, default.toString()).toInt()
    }

    fun getPropertyBoolean(property: String, default: Boolean): Boolean {
        return props.getProperty(property, default.toString()).toBoolean()
    }
}