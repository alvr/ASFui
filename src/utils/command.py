import requests
import time
from PyQt5.QtCore import QObject, pyqtSlot

from requests.exceptions import ConnectionError
from utils.settings import Settings


REDEEM = 'r'
REDEEM_MODE = 'r^'
LICENSE = 'addlicense'
FARM = 'farm'
LOOT = 'loot'
LOOT_ALL = 'loot ASF'
UNPACK = 'unpack'
OWN = 'owns'
OWN_ALL = 'oa'
PLAY = 'play'
START = 'start'
START_ALL = 'start ASF'
STOP = 'stop'
PAUSE = 'pause'
RESUME = 'resume'
PASSWORD = 'password'
STATUS = 'status'
STATUS_ALL = 'sa'
REJOIN_CHAT = 'rejoinchat'
UPDATE = 'update'
VERSION = 'version'
API = 'api ASF'
TWOFA = '2fa'
TWOFA_ACCEPT = '2faok'
TWOFA_DENY = '2fano'
BLACKLIST = 'bl'
BLACKLIST_ADD = 'bladd'
BLACKLIST_REMOVE = 'blrm'
IDLING = 'iq'
IDLING_ADD = 'iqadd'
IDLING_REMOVE = 'iqrm'


def generate_command(command, user='', args='', pre=''):
    return (command + ' ' + user + ' ' + pre + ' ' + args).strip()


def send_command(command):
    params = {'command': command}
    base_url = Settings().get_setting('host')

    try:
        response = requests.get(base_url + '/IPC', params=params).text
    except ConnectionError:
        response = 'Error sending command "{}". ArchiSteamFarm may be not running.'.format(command)

    return response.strip()
