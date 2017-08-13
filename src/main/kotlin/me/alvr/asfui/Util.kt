package me.alvr.asfui

object Util {
    fun multiToOne(input: String): String = input
            .replace("\r\n", "\n")
            .replace("\r", "\n")
            .split("\n")
            .map {
                it.trim()
            }
            .filterNot {
                it == ""
            }.joinToString(",")
}