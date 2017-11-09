import requests

from requests.exceptions import ConnectionError
from utils.config import Config


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
REJOIN = 'rejoinchat'
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
    args = ','.join([arg for arg in args.splitlines() if arg])
    return (command + ' ' + user + ' ' + pre + ' ' + args).strip()


def send_command(command):
    params = {'command': command}
    base_url = Config().get('host')

    try:
        response = requests.get(base_url + '/IPC', params=params).text
    except ConnectionError:
        response = 'Error sending command {}. ArchiSteamFarm may be not running.'.format(command)

    return response.strip()
