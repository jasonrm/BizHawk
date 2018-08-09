from BizHawk.Client.EmuHawk import GlobalWin

class GraphicsContext():
    def __init__(self, name="emu", clear=True):
        self.name = name
        self.clear = clear
    def __enter__(self):
        self.luaSurface = GlobalWin.DisplayManager.LockLuaSurface(self.name, self.clear)
        return self.luaSurface.GetGraphics()
    def __exit__(self, type, value, traceback):
        GlobalWin.DisplayManager.UnlockLuaSurface(self.luaSurface)

def add_message(message):
    GlobalWin.OSD.AddMessage(message);
