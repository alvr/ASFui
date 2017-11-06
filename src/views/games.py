import threading

from PyQt5 import uic
from PyQt5.QtWidgets import QWidget

from utils.command import generate_command, send_command, OWN, OWN_ALL, PLAY
from utils.resources import resource_path


class Games(QWidget):
    def __init__(self, bots, data):
        super().__init__()

        uic.loadUi(resource_path('src/resources/ui/games.ui'), self)

        self.bots = bots
        self.data = data
        self.games_own.clicked.connect(self.own)
        self.games_own_all.clicked.connect(self.own_all)
        self.games_play.clicked.connect(self.play)

    def own(self):
        command = generate_command(OWN, self.bots.currentText(), self.data.toPlainText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def own_all(self):
        command = generate_command(OWN_ALL, self.bots.currentText(), self.data.toPlainText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def play(self):
        command = generate_command(PLAY, self.bots.currentText(), self.data.toPlainText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()
