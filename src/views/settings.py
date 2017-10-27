import os

import sys
from PyQt5 import uic
from PyQt5.QtCore import QDir
from PyQt5.QtGui import QIcon
from PyQt5.QtWidgets import QDialog, QFileDialog

from utils.resources import resource_path


class Settings(QDialog):
    def __init__(self):
        super(Settings, self).__init__()

        self.setWindowIcon(QIcon(resource_path('src/resources/images/icon.ico')))
        uic.loadUi(resource_path('src/resources/ui/settings.ui'), self)

        self.btn_search_binary.clicked.connect(self.search_binary)

    def search_binary(self):
        dialog = QFileDialog()
        if sys.platform == 'win32':
            file = dialog.getOpenFileName(self, 'Select input', os.path.expanduser('~'), 'Executable files (*.exe)')
        else:
            dialog.setFilter(QDir.Executable | QDir.Files)
            file = dialog.getOpenFileName(self, 'Select input', os.path.expanduser('~'))

        if file[0]:
            self.lb_path.setText(file[0])
