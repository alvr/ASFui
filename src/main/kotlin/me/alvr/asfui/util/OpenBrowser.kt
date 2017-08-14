package me.alvr.asfui.util

import tornadofx.Controller

class OpenBrowser : Controller() {
    fun openUrl(url: String) {
        hostServices.showDocument(url)
    }
}