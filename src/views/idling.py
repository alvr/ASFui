import threading

from PyQt5 import uic
from PyQt5.QtWidgets import QWidget

from utils.command import generate_command, send_command, IDLING, IDLING_ADD, IDLING_REMOVE
from utils.resources import resource_path


class Idling(QWidget):
    def __init__(self, bots, data):
        super().__init__()

        uic.loadUi(resource_path('src/resources/ui/idling.ui'), self)

        self.bots = bots
        self.data = data
        self.idling_list.clicked.connect(self.list)
        self.idling_add.clicked.connect(self.add)
        self.idling_remove.clicked.connect(self.remove)

    def list(self):
        command = generate_command(IDLING, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def add(self):
        command = generate_command(IDLING_ADD, self.bots.currentText(), self.data.toPlainText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def remove(self):
        command = generate_command(IDLING_REMOVE, self.bots.currentText(), self.data.toPlainText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()
