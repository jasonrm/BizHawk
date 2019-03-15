import ast
import sys
import code
from System import Console
from BizHawk.Client.EmuHawk import PythonBridge

class PythonConsoleOutput(object):
    def write(self, msg):
        PythonBridge.ConsoleLog(msg)
    def writelines(self, msgs):
        for msg in msgs:
            PythonBridge.ConsoleLog(msg)
    def flush(self):
        pass
    def close(self):
        pass


class ApplicationConsoleOutput(object):
    def write(self, msg):
        Console.Out.Write(msg)
    def writelines(self, msgs):
        for msg in msgs:
            Console.Out.Write(msg)
    def flush(self):
        pass
    def close(self):
        pass


def enable_debug():
	import ptvsd
	ptvsd.enable_attach(address=('127.0.0.1', 5678))


def wire_console():
    sys.stdout = sys.stderr = PythonConsoleOutput()

repl_globals = {}
repl_locals = {}

# via: https://stackoverflow.com/a/38615712
def eval_from_input(code):
    ast_ = ast.parse(code, '<code>', 'exec')
    final_expr = None
    for field_ in ast.iter_fields(ast_):
        if 'body' != field_[0]:
            continue
        if len(field_[1]) > 0 and isinstance(field_[1][-1], ast.Expr):
            final_expr = ast.Expression()
            final_expr.body = field_[1].pop().value
    rv = None
    exec(compile(ast_, '<code>', 'exec'), repl_globals, repl_locals)
    if final_expr:
        rv = eval(compile(final_expr, '<code>', 'eval'), repl_globals, repl_locals)
    return rv
