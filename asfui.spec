# -*- mode: python -*-
import os

import sys
from PyInstaller.building.api import PYZ, EXE
from PyInstaller.building.build_main import Analysis

block_cipher = None

added_files = [
    (os.path.abspath('src/resources/images/*.png'), 'src/resources/images/'),
    (os.path.abspath('src/resources/ui/*.ui'), 'src/resources/ui/'),
]


def icon_path():
    if sys.platform == 'win32':
        return os.path.abspath('src/resources/images/icon.ico')
    elif sys.platform == 'darwin':
        return os.path.abspath('src/resources/images/icon.icns')
    else:
        return ''


a = Analysis([os.path.abspath('src/asfui.py')],
             pathex=[os.getcwd()],
             binaries=[],
             datas=added_files,
             hiddenimports=[],
             hookspath=[],
             runtime_hooks=[],
             excludes=[],
             win_no_prefer_redirects=False,
             win_private_assemblies=False,
             cipher=block_cipher
             )

pyz = PYZ(a.pure, a.zipped_data, cipher=block_cipher)

exe = EXE(pyz,
          a.scripts,
          a.binaries,
          a.zipfiles,
          a.datas,
          name='ASFui',
          debug=False,
          strip=False,
          upx=False,
          runtime_tmpdir=None,
          console=False,
          icon=icon_path(),
          version=os.path.abspath('src/resources/version.txt')
          )
