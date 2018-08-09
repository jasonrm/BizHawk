from BizHawk.Client.EmuHawk import PythonBridge

thread = None

def frame_count():
	return PythonBridge.Emulator.Frame

def frame_advance():
	thread.Yield()