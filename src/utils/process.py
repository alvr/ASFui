import threading
import psutil


def is_asf_running():
    processes = []
    for p in psutil.process_iter():
        processes.append(p.name().lower())
    return 'archi' in processes or 'asf' in processes


class ASFProcess(threading.Thread):

    def __init__(self):
        super().__init__()
        self.daemon = True
        self._stop = threading.Event()

    def run(self):
        while not self.stopped():
            pass

    def stop(self):
        self._stop.set()

    def stopped(self):
        return self._stop.isSet()
