import sys
import traceback

from PyQt5.QtWidgets import QApplication, QMessageBox

from utils.message_error import MessageError
from views.main import ASFui

sys._excepthook = sys.excepthook


def show_error(te, v, tb):
    error = MessageError()
    error.setFixedSize(300, 250)
    error.setIcon(QMessageBox.Critical)
    error.setWindowTitle('An error ocurred ({})'.format(te.__name__))
    error.setText(str(v))
    error.setDetailedText(''.join(traceback.format_tb(tb)))
    error.exec_()


sys.excepthook = show_error

if __name__ == '__main__':
    app = QApplication(sys.argv)
    app.setQuitOnLastWindowClosed(True)
    app.setStyle('fusion')

    window = ASFui()
    window.show()
    sys.exit(app.exec_())
