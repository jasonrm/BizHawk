from BizHawk.Client.EmuHawk import PythonBridge

def frame_count():
    return PythonBridge.Emulator.Frame

def frame_advance():
    PythonBridge.YieldCurrentThread()
