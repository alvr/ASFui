import threading

from PyQt5 import uic
from PyQt5.QtWidgets import QWidget

from utils.command import generate_command, TWOFA, send_command, TWOFA_ACCEPT, TWOFA_DENY
from utils.resources import resource_path


class TwoFA(QWidget):
    def __init__(self, bots):
        super().__init__()

        self.bots = bots
        uic.loadUi(resource_path('src/resources/ui/2fa.ui'), self)

        self.twofa_generate.clicked.connect(self.generate)
        self.twofa_accept.clicked.connect(self.accept)
        self.twofa_deny.clicked.connect(self.deny)

    def generate(self):
        command = generate_command(TWOFA, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def accept(self):
        command = generate_command(TWOFA_ACCEPT, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def deny(self):
        command = generate_command(TWOFA_DENY, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()
