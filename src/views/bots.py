import threading

from PyQt5 import uic
from PyQt5.QtWidgets import QWidget

from utils.command import generate_command, START_ALL, send_command, START, STATUS_ALL, STATUS, PASSWORD, RESUME, \
    PAUSE, STOP
from utils.resources import resource_path


class Bots(QWidget):
    def __init__(self, bots):
        super().__init__()

        uic.loadUi(resource_path('src/resources/ui/bots.ui'), self)

        self.bots = bots
        self.bots_start.clicked.connect(self.start)
        self.bots_start_all.clicked.connect(self.start_all)
        self.bots_stop.clicked.connect(self.stop)
        self.bots_pause.clicked.connect(self.pause)
        self.bots_resume.clicked.connect(self.resume)
        self.bots_password.clicked.connect(self.password)
        self.bots_status.clicked.connect(self.status)
        self.bots_status_all.clicked.connect(self.status_all)

    def start(self):
        command = generate_command(START, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def start_all(self):
        command = generate_command(START_ALL)
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def stop(self):
        command = generate_command(STOP, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def pause(self):
        command = generate_command(PAUSE, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def resume(self):
        command = generate_command(RESUME, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def password(self):
        command = generate_command(PASSWORD, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def status(self):
        command = generate_command(STATUS, self.bots.currentText())
        threading.Thread(target=send_command, args=(command,), daemon=True).start()

    def status_all(self):
        command = generate_command(STATUS_ALL)
        threading.Thread(target=send_command, args=(command,), daemon=True).start()