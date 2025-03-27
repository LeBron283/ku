import ctypes
from ctypes import c_uint16, c_double, c_int16

# 加载 move.dll
_move_dll = ctypes.WinDLL('move.dll')

# 定义各函数的参数和返回类型
_move_dll.CardInit.argtypes = []
_move_dll.CardInit.restype = ctypes.c_bool

_move_dll.checkAxisIsStopped.argtypes = [c_uint16]
_move_dll.checkAxisIsStopped.restype = ctypes.c_bool

_move_dll.setAxisRunMode.argtypes = [c_uint16, c_uint16, c_uint16]
_move_dll.setAxisRunMode.restype = None

_move_dll.setAxisSpeed.argtypes = [c_uint16, c_double]
_move_dll.setAxisSpeed.restype = None

_move_dll.setAxisAddDecTime.argtypes = [c_uint16, c_double]
_move_dll.setAxisAddDecTime.restype = None

_move_dll.setAxisBackHash.argtypes = [c_uint16, c_double]
_move_dll.setAxisBackHash.restype = None

_move_dll.setAxisDangLiang.argtypes = [c_uint16, c_double]
_move_dll.setAxisDangLiang.restype = None

_move_dll.getNowPosition.argtypes = [c_uint16]
_move_dll.getNowPosition.restype = c_double

_move_dll.setNowPosition.argtypes = [c_uint16, c_double]
_move_dll.setNowPosition.restype = None

_move_dll.singleImdStop.argtypes = [c_uint16]
_move_dll.singleImdStop.restype = None

_move_dll.AllAxisStop.argtypes = []
_move_dll.AllAxisStop.restype = None

_move_dll.pMoveRef.argtypes = [c_uint16, c_double]
_move_dll.pMoveRef.restype = None

_move_dll.pMoveAbs.argtypes = [c_uint16, c_double]
_move_dll.pMoveAbs.restype = None

_move_dll.vMove.argtypes = [c_uint16, c_int16]
_move_dll.vMove.restype = None

_move_dll.setIOOut.argtypes = [c_uint16, c_uint16, c_uint16]
_move_dll.setIOOut.restype = None

_move_dll.getIOOut.argtypes = [c_uint16, c_uint16]
_move_dll.getIOOut.restype = ctypes.c_int

_move_dll.waitStop.argtypes = [c_uint16]
_move_dll.waitStop.restype = None

_move_dll.CardClose.argtypes = []
_move_dll.CardClose.restype = None

class USBMove:
    @staticmethod
    def init() -> bool:
        """初始化控制卡"""
        return _move_dll.CardInit()

    @staticmethod
    def check_stopped(axis: int) -> bool:
        """检查指定轴是否已停止"""
        return _move_dll.checkAxisIsStopped(c_uint16(axis))

    @staticmethod
    def set_axis_run_mode(axis: int, out_mode: int, el_level: int) -> None:
        """设置轴运行模式"""
        _move_dll.setAxisRunMode(c_uint16(axis), c_uint16(out_mode), c_uint16(el_level))

    @staticmethod
    def set_axis_speed(axis: int, speed: float) -> None:
        """设置轴速度（直线单位：微米/s, 角度单位：度/s）"""
        _move_dll.setAxisSpeed(c_uint16(axis), c_double(speed))

    @staticmethod
    def set_add_dec_time(axis: int, time_sec: float) -> None:
        """设置加减速时间，单位为秒"""
        _move_dll.setAxisAddDecTime(c_uint16(axis), c_double(time_sec))

    @staticmethod
    def set_axis_backhash(axis: int, backhash: float) -> None:
        """设置反向间隙补偿值"""
        _move_dll.setAxisBackHash(c_uint16(axis), c_double(backhash))

    @staticmethod
    def set_axis_dangliang(axis: int, dangliang: float) -> None:
        """设置轴脉冲当量"""
        _move_dll.setAxisDangLiang(c_uint16(axis), c_double(dangliang))

    @staticmethod
    def get_pos(axis: int) -> float:
        """获取轴当前位置"""
        return _move_dll.getNowPosition(c_uint16(axis))

    @staticmethod
    def set_pos(axis: int, pos: float) -> None:
        """设定轴当前位置"""
        _move_dll.setNowPosition(c_uint16(axis), c_double(pos))

    @staticmethod
    def imd_stop(axis: int) -> None:
        """单轴急停"""
        _move_dll.singleImdStop(c_uint16(axis))

    @staticmethod
    def all_stop() -> None:
        """全部轴急停"""
        _move_dll.AllAxisStop()

    @staticmethod
    def p_move_ref(axis: int, distance: float) -> None:
        """指定轴执行相对运动，正值为正向移动"""
        _move_dll.pMoveRef(c_uint16(axis), c_double(distance))

    @staticmethod
    def p_move_abs(axis: int, pos: float) -> None:
        """指定轴执行绝对运动"""
        _move_dll.pMoveAbs(c_uint16(axis), c_double(pos))

    @staticmethod
    def v_move(axis: int, direction: int) -> None:
        """指定轴连续运动，方向1为正向，-1为负向"""
        _move_dll.vMove(c_uint16(axis), c_int16(direction))

    @staticmethod
    def set_io_out(axis: int, bit_no: int, on_off: int) -> None:
        """设置指定轴的IO口状态（0关闭，1开启）"""
        _move_dll.setIOOut(c_uint16(axis), c_uint16(bit_no), c_uint16(on_off))

    @staticmethod
    def get_io_out(axis: int, bit_no: int) -> int:
        """获取指定轴的IO口状态"""
        return _move_dll.getIOOut(c_uint16(axis), c_uint16(bit_no))

    @staticmethod
    def wait_stop(axis: int) -> None:
        """阻塞等待指定轴停止运动"""
        _move_dll.waitStop(c_uint16(axis))

    @staticmethod
    def end_close() -> None:
        """释放控制卡资源"""
        _move_dll.CardClose()