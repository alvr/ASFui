from PyQt5 import uic
from PyQt5.QtWidgets import QWidget

from utils.resources import resource_path


class ASF(QWidget):
    def __init__(self):
        super().__init__()

        uic.loadUi(resource_path('src/resources/ui/asf.ui'), self)
