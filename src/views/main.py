import os
import webbrowser

from PyQt5 import uic
from PyQt5.QtGui import QIcon
from PyQt5.QtWidgets import QMainWindow, QFileDialog, QPushButton, QMessageBox

from utils import command
from utils.process import ASFProcess, is_asf_running
from utils.resources import resource_path
from views.bots import Bots
from views.settings import Settings
from views.twofa import TwoFA


class ASFui(QMainWindow):
    def __init__(self):
        super(ASFui, self).__init__()

        self.setWindowIcon(QIcon(resource_path('src/resources/images/logo.png')))
        self.setFixedSize(805, 700)
        self.setContentsMargins(7.5, 7.5, 7.5, 7.5)

        uic.loadUi(resource_path('src/resources/ui/main.ui'), self)

        self.asf_process: ASFProcess = None

        # Main Menu
        self.btn_start.clicked.connect(self.start_process)          # Start
        self.btn_stop.clicked.connect(self.stop_process)            # Stop
        self.btn_clear.clicked.connect(self.clear_log)              # Clear Log
        self.btn_settings.clicked.connect(self.show_settings)       # Settings
        self.btn_help.clicked.connect(self.show_help)               # Help
        self.btn_reload.clicked.connect(self.reload_bots)           # Reload
        self.btn_load_input.clicked.connect(self.load_input)        # Load Input

        # Controls
        self.btn_manage.clicked.connect(self.manage)                # Manage Bots
        self.btn_redeem.clicked.connect(self.redeem)                # Redeem
        self.btn_licenses.clicked.connect(self.licenses)            # Licenses
        self.btn_cards.clicked.connect(self.cards)                  # Cards
        self.btn_games.clicked.connect(self.games)                  # Games
        self.btn_asf.clicked.connect(self.asf)                      # ArchiSteamFarm
        self.btn_2fa.clicked.connect(self.twofa)                    # 2FA
        self.btn_blacklist.clicked.connect(self.blacklist)          # Blacklist
        self.btn_idling.clicked.connect(self.idling)                # Priority Idling

    # Main
    def start_process(self):
        if not is_asf_running():
            if self.asf_process is None:
                self.output.insertPlainText('Starting ASF...\n')
                self.asf_process = ASFProcess()
                self.asf_process.start()
        else:
            msg = QMessageBox()
            msg.setWindowIcon(QIcon(resource_path('src/resources/images/logo.png')))
            msg.setWindowTitle('ASF is running')
            msg.setIcon(QMessageBox.Warning)
            msg.setText('ASF is already running, please close it before starting ASFui.')
            msg.setStandardButtons(QMessageBox.Ok)
            msg.exec_()

    def stop_process(self):
        if self.asf_process is not None:
            self.output.insertPlainText('Stopping ASF...\n')
            self.asf_process.stop()
            self.asf_process = None

    def clear_log(self):
        self.output.clear()

    def show_settings(self):
        Settings().exec_()

    def show_help(self):
        webbrowser.open_new_tab('https://github.com/alvr/ASFui/wiki')

    def reload_bots(self):
        pass

    def load_input(self):
        dialog = QFileDialog()
        file = dialog.getOpenFileName(self, 'Select input', os.path.expanduser('~'), 'Text files (*.txt)')

        if file[0]:
            self.input.clear()
            with open(file[0]) as f:
                self.input.appendPlainText(f.read())

    # Controls
    def manage(self):
        self._clear_layout(self.gb_options_layout)
        self.gb_options_layout.addWidget(Bots(self.cb_bots))

    def redeem(self):
        self._clear_layout(self.gb_options_layout)
        pass

    def licenses(self):
        self._clear_layout(self.gb_options_layout)
        pass

    def cards(self):
        self._clear_layout(self.gb_options_layout)
        pass

    def games(self):
        self._clear_layout(self.gb_options_layout)
        pass

    def asf(self):
        self._clear_layout(self.gb_options_layout)
        pass

    def twofa(self):
        self._clear_layout(self.gb_options_layout)
        self.gb_options_layout.addWidget(TwoFA(self.cb_bots))

    def blacklist(self):
        self._clear_layout(self.gb_options_layout)
        pass

    def idling(self):
        self._clear_layout(self.gb_options_layout)
        pass

    def _clear_layout(self, layout):
        while layout.count():
            child = layout.takeAt(0)
            if child.widget():
                child.widget().deleteLater()
