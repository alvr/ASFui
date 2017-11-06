import threading

from PyQt5 import uic
from PyQt5.QtWidgets import QWidget

from utils.command import generate_command, send_command, FARM, LOOT, LOOT_ALL, UNPACK
from utils.resources import resource_path


class Cards(QWidget):
    def __init__(self, bots):
        super().__init__()

        uic.loadUi(resource_path('src/resources/ui/cards.ui'), self)

        self.bots = bots
        self.cards_farm.clicked.connect(self.farm)
        self.cards_loot.clicked.connect(self.loot)
        self.cards_loot_all.clicked.connect(self.loot_all)
        self.cards_unpack.clicked.connect(self.unpack)

    def farm(self):
        command = generate_command(FARM, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def loot(self):
        command = generate_command(LOOT, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def loot_all(self):
        command = generate_command(LOOT_ALL, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def unpack(self):
        command = generate_command(UNPACK, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()
