import sys
from os.path import expanduser

from PyQt5 import uic
from PyQt5.QtCore import QDir
from PyQt5.QtGui import QIcon
from PyQt5.QtWidgets import QDialog, QFileDialog, QDialogButtonBox

from utils.config import Config
from utils.resources import resource_path


class Settings(QDialog):
    def __init__(self):
        super(Settings, self).__init__()

        self.setWindowIcon(QIcon(resource_path('src/resources/images/icon.ico')))
        uic.loadUi(resource_path('src/resources/ui/settings.ui'), self)

        self.config = Config()
        self.load()

        self.btn_search_binary.clicked.connect(self.search_binary)
        self.buttons.button(QDialogButtonBox.SaveAll).clicked.connect(self.save)

    def search_binary(self):
        dialog = QFileDialog()
        if sys.platform == 'win32':
            file = dialog.getOpenFileName(self, 'Select input', expanduser('~'), 'Executable files (*.exe)')
        else:
            dialog.setFilter(QDir.Executable | QDir.Files)
            file = dialog.getOpenFileName(self, 'Select input', expanduser('~'))

        if file[0]:
            self.lb_path.setText(file[0])

    def load(self):
        self.lb_path.setText(self.config.get('binary'))
        self.cb_redeemed.setChecked(self.config.get('redeemed'))
        self.cb_duplicated.setChecked(self.config.get('duplicated'))
        self.cb_invalid.setChecked(self.config.get('invalid'))
        self.cb_owned.setChecked(self.config.get('owned'))
        self.cb_cooldown.setChecked(self.config.get('cooldown'))
        self.cb_autostart.setChecked(self.config.get('autostart'))
        self.cb_minimize.setChecked(self.config.get('minimize'))

    def save(self):
        data = {
            'binary': self.lb_path.text(),
            'host': 'http://127.0.0.1:1242',
            'redeemed': self.cb_redeemed.isChecked(),
            'duplicated': self.cb_duplicated.isChecked(),
            'invalid': self.cb_invalid.isChecked(),
            'owned': self.cb_owned.isChecked(),
            'cooldown': self.cb_cooldown.isChecked(),
            'autostart': self.cb_autostart.isChecked(),
            'minimize': self.cb_minimize.isChecked()
        }
        self.config.save(data)
