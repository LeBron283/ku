import ctypes

# 加载 sensor.dll
_sensor_dll = ctypes.WinDLL('sensor.dll')

# 定义各函数的参数和返回类型
_sensor_dll.sensorInit.argtypes = [ctypes.c_int]
_sensor_dll.sensorInit.restype = ctypes.c_int

_sensor_dll.getComPort.argtypes = []
_sensor_dll.getComPort.restype = ctypes.c_int

_sensor_dll.getSensor.argtypes = [ctypes.c_int]
_sensor_dll.getSensor.restype = ctypes.c_int

_sensor_dll.setZero.argtypes = [ctypes.c_int, ctypes.c_int]
_sensor_dll.setZero.restype = None

_sensor_dll.closeSensor.argtypes = []
_sensor_dll.closeSensor.restype = None

class Sensor:
    @staticmethod
    def init(com_name: int) -> int:
        """初始化传感器，返回初始化状态"""
        return _sensor_dll.sensorInit(com_name)

    @staticmethod
    def get_com_name() -> int:
        """获取实际使用的传感器串口号"""
        return _sensor_dll.getComPort()

    @staticmethod
    def get_sensor(channel: int) -> int:
        """获取指定通道的传感器值"""
        return _sensor_dll.getSensor(channel)

    @staticmethod
    def set_zero(channel: int, zero: int) -> None:
        """设置传感器归零值"""
        _sensor_dll.setZero(channel, zero)

    @staticmethod
    def end_close() -> None:
        """释放传感器资源"""
        _sensor_dll.closeSensor()