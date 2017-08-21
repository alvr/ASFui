package me.alvr.asfui.util

import org.apache.commons.io.FileUtils
import java.io.File
import java.util.Properties

object ConfigManager {
    private val configFile = "asfui.properties"
    private val props = Properties()

    fun loadProperties() {
        if (!File(configFile).exists()) {
            val config = ClassLoader.getSystemResource("asfui.properties")
            FileUtils.copyURLToFile(config, File(configFile))
        }

        File(configFile).inputStream().use { f ->
            props.load(f)
        }
    }

    fun set(property: String, value: Any, message: String = "Configuration saved.") {
        props.setProperty(property, value.toString())
        File(configFile).outputStream().use { f ->
            props.store(f, message)
        }
    }

    fun string(property: String, default: String): String {
        return props.getProperty(property, default)
    }

    fun string(property: String): String {
        return props.getProperty(property)
    }

    fun int(property: String, default: Int): Int {
        return props.getProperty(property, default.toString()).toInt()
    }

    fun int(property: String): Int {
        return props.getProperty(property).toInt()
    }

    fun boolean(property: String, default: Boolean): Boolean {
        return props.getProperty(property, default.toString()).toBoolean()
    }

    fun boolean(property: String): Boolean {
        return props.getProperty(property).toBoolean()
    }
}