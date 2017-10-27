import sys

from PyQt5.QtWidgets import QApplication

from views.main import ASFui

if __name__ == '__main__':
    app = QApplication(sys.argv)
    app.setQuitOnLastWindowClosed(True)
    app.setStyle('fusion')

    window = ASFui()
    window.show()
    sys.exit(app.exec_())
