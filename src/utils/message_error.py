from PyQt5.QtGui import QFontDatabase
from PyQt5.QtWidgets import QMessageBox, QTextEdit


class MessageError(QMessageBox):

    def __init__(self, *args):
        super(MessageError, self).__init__(*args)
        self.setMinimumWidth(500)

    def resizeEvent(self, event):
        result = super(MessageError, self).resizeEvent(event)
        details_box = self.findChild(QTextEdit)
        if details_box is not None:
            details_box.setFixedHeight(300)
            font = QFontDatabase().systemFont(QFontDatabase.FixedFont)
            details_box.setFont(font)

        return result
