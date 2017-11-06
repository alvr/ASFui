import threading
import webbrowser

from PyQt5 import uic
from PyQt5.QtWidgets import QWidget

from utils.command import generate_command, send_command, REJOIN, UPDATE, VERSION, API
from utils.resources import resource_path


class ASF(QWidget):
    def __init__(self, bots):
        super().__init__()

        uic.loadUi(resource_path('src/resources/ui/asf.ui'), self)

        self.bots = bots
        self.asf_help.clicked.connect(self.help)
        self.asf_rejoin.clicked.connect(self.rejoin)
        self.asf_update.clicked.connect(self.up)
        self.asf_version.clicked.connect(self.version)
        self.asf_api.clicked.connect(self.api)

    def help(self):
        webbrowser.open_new_tab('https://github.com/JustArchi/ArchiSteamFarm/wiki')

    def rejoin(self):
        command = generate_command(REJOIN, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def up(self):
        threading.Thread(target=send_command, args=(UPDATE,), daemon=True).start()

    def version(self):
        threading.Thread(target=send_command, args=(VERSION,), daemon=True).start()

    def api(self):
        command = generate_command(API, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()
