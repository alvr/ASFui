import threading

from PyQt5 import uic
from PyQt5.QtWidgets import QWidget

from utils.command import generate_command, send_command, REDEEM_MODE, REDEEM
from utils.resources import resource_path


class Redeem(QWidget):
    def __init__(self, bots, data):
        super().__init__()

        uic.loadUi(resource_path('src/resources/ui/redeem.ui'), self)

        self.bots = bots
        self.data = data
        self.redeem_normal.clicked.connect(self.redeem)
        self.redeem_si.setProperty('value', 'si')
        self.redeem_fd.setProperty('value', 'fd')
        self.redeem_sd.setProperty('value', 'sd')
        self.redeem_ff.setProperty('value', 'ff')
        self.redeem_sf.setProperty('value', 'sf')
        self.redeem_fkmg.setProperty('value', 'fkmg')
        self.redeem_skmg.setProperty('value', 'skmg')
        self.redeem_v.setProperty('value', 'v')

    def redeem(self):
        result = []
        for btn in [self.redeem_si, self.redeem_fd, self.redeem_sd, self.redeem_ff, self.redeem_sf, self.redeem_fkmg,
                    self.redeem_skmg, self.redeem_v]:
            if btn.isChecked():
                result.append(btn.property('value'))

        if result:
            methods = ','.join(result)
            command = generate_command(REDEEM_MODE, self.bots.currentText(), self.data.toPlainText(), methods)
            threading.Thread(target=send_command, args=(command,), daemon=True).start()
        else:
            command = generate_command(REDEEM, self.bots.currentText(), self.data.toPlainText())
            threading.Thread(target=send_command, args=(command,), daemon=True).start()
