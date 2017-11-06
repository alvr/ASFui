import threading

from PyQt5 import uic
from PyQt5.QtWidgets import QWidget

from utils.command import generate_command, send_command, LICENSE
from utils.resources import resource_path


class Licenses(QWidget):
    def __init__(self, bots, data):
        super().__init__()

        uic.loadUi(resource_path('src/resources/ui/licenses.ui'), self)

        self.bots = bots
        self.data = data
        self.licenses_add.clicked.connect(self.add)
        self.licenses_add_all.clicked.connect(self.add_all)

    def add(self):
        command = generate_command(LICENSE, self.bots.currentText(), self.data.toPlainText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def add_all(self):
        for bot in [self.bots.itemText(i) for i in range(self.bots.count())]:
            command = generate_command(LICENSE, bot, self.data.toPlainText())
            threading.Thread(target=send_command, args=(command,), daemon=True).start()
