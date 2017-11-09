import json

import anyconfig
import os


class Config:

    __instance = None

    def __new__(cls):
        if Config.__instance is None:
            Config.__instance = object.__new__(cls)
        return Config.__instance

    def __init__(self):
        self.config_file = os.path.abspath('asfui.json')
        self.__load_defaults()
        self.config = anyconfig.load(self.config_file)

    def get(self, key):
        return self.config.get(key)

    def save(self, data):
        anyconfig.dump(data, self.config_file, **{'indent': 4})

    def __load_defaults(self):
        default = {
            'binary': '',
            'host': 'http://127.0.0.1:1242',
            'redeemed': True,
            'duplicated': False,
            'invalid': False,
            'owned': False,
            'cooldown': False,
            'autostart': False,
            'minimize': False
        }

        try:
            with open(self.config_file, 'x') as f:
                json.dump(default, f, indent=4)
        except FileExistsError:
            with open(self.config_file, 'r+') as f:
                result = {**default, **json.load(f)}
                f.seek(0)
                json.dump(result, f, indent=4)
                f.truncate()
