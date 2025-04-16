import ctypes

# 加载 power.dll
_power_dll = ctypes.WinDLL('power.dll')

# 定义各函数的参数和返回类型
_power_dll.comInit.argtypes = [ctypes.c_int]
_power_dll.comInit.restype = ctypes.c_int

_power_dll.getComName.argtypes = []
_power_dll.getComName.restype = ctypes.c_int

_power_dll.getPower.argtypes = [ctypes.c_int]
_power_dll.getPower.restype = ctypes.c_double

_power_dll.getPowerEx.argtypes = [ctypes.c_int]
_power_dll.getPowerEx.restype = ctypes.c_double

_power_dll.setZero.argtypes = [ctypes.c_int, ctypes.c_double]
_power_dll.setZero.restype = None

_power_dll.selWaveLength.argtypes = [ctypes.c_int, ctypes.c_int]
_power_dll.selWaveLength.restype = None

_power_dll.endClose.argtypes = []
_power_dll.endClose.restype = None

class PM:
    @staticmethod
    def init(com_name: int) -> int:
        """初始化功率计，返回初始化状态"""
        return _power_dll.comInit(com_name)

    @staticmethod
    def get_com_name() -> int:
        """获取实际使用的串口号"""
        return _power_dll.getComName()

    @staticmethod
    def get_power(channel: int) -> float:
        """获取功率值"""
        return _power_dll.getPower(channel)

    @staticmethod
    def get_power_ex(channel: int) -> float:
        """等待更新并获取功率值"""
        return _power_dll.getPowerEx(channel)

    @staticmethod
    def set_zero(channel: int, zero: float) -> None:
        """设置归零值"""
        _power_dll.setZero(channel, zero)

    @staticmethod
    def sel_wave_length(channel: int, wavelength: int) -> None:
        """设置波长，如1310或1550"""
        _power_dll.selWaveLength(channel, wavelength)

    @staticmethod
    def end_close() -> None:
        """释放功率计资源"""
        _power_dll.endClose()