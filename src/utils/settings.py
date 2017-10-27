import os
from PyQt5.QtCore import QSettings


class Settings:

    def __init__(self):
        self.settings_file = os.path.abspath('asfui.ini')
        self.settings = QSettings(self.settings_file, QSettings.IniFormat)

        self.load_defaults()

    def get_setting(self, key: str):
        return self.settings.value(key)

    def save_setting(self, key, value):
        self.settings.setValue(key, value)

    def save_settings(self, settings):
        for setting in settings:
            self.settings.setValue(setting[0], setting[1])

    def load_defaults(self):
        if not os.path.exists(self.settings_file):
            self.settings.setValue('binary', '')
            self.settings.setValue('host', 'http://127.0.0.1:1242')
            self.settings.setValue('redeemed', True)
            self.settings.setValue('duplicated', False)
            self.settings.setValue('invalid', False)
            self.settings.setValue('owned', False)
            self.settings.setValue('cooldown', False)
            self.settings.setValue('autostart', False)
