import threading

from PyQt5 import uic
from PyQt5.QtWidgets import QWidget

from utils.command import generate_command, send_command, BLACKLIST, BLACKLIST_ADD, BLACKLIST_REMOVE
from utils.resources import resource_path


class Blacklist(QWidget):
    def __init__(self, bots, data):
        super().__init__()

        uic.loadUi(resource_path('src/resources/ui/blacklist.ui'), self)

        self.bots = bots
        self.data = data
        self.blacklist_list.clicked.connect(self.list)
        self.blacklist_add.clicked.connect(self.add)
        self.blacklist_remove.clicked.connect(self.remove)

    def list(self):
        command = generate_command(BLACKLIST, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def add(self):
        command = generate_command(BLACKLIST_ADD, self.bots.currentText(), self.data.toPlainText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def remove(self):
        command = generate_command(BLACKLIST_REMOVE, self.bots.currentText(), self.data.toPlainText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()
