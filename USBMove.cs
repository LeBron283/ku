using System;
using System.Runtime.InteropServices;

namespace WindowsFormsApp3
{
    internal class USBMove
    {
        /// <summary>
        /// 控制卡初始化 , 软件启动调用一次即可
        /// </summary>
        /// <returns>是否成功</returns>
        [DllImport("move.dll", EntryPoint = "CardInit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool Init();
        /// <summary>
        /// 检查指定轴是否已停止运动
        /// </summary>
        /// <param name="axis">轴号 , 从0-5</param>
        /// <returns>是否停止</returns>
        [DllImport("move.dll", EntryPoint = "checkAxisIsStopped", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool checkStopped(UInt16 axis);
        /// <summary>
        /// 设置轴控制模式
        /// </summary>
        /// <param name="axis">轴号 , 从0-5</param>
        /// <param name="outmode">脉冲模式,1正常方向模式,2反向模式</param>
        /// <param name="ELlevel">限位信号电平</param>
        [DllImport("move.dll", EntryPoint = "setAxisRunMode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void setAxisRunMode(UInt16 axis, UInt16 outmode, UInt16 ELlevel);
        /// <summary>
        /// 设置轴运动速度
        /// </summary>
        /// <param name="axis">轴号 , 从0-5</param>
        /// <param name="speed">速度 , 直线轴单位是:微米/s, 角度轴单位是:度/s</param>
        [DllImport("move.dll", EntryPoint = "setAxisSpeed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void setAxisSpeed(UInt16 axis, double speed);
        /// <summary>
        /// 设置轴运行加减速时长
        /// </summary>
        /// <param name="axis">轴号 , 从0-5<</param>
        /// <param name="ctime">时长,单位:秒</param>
        [DllImport("move.dll", EntryPoint = "setAxisAddDecTime", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void setAddDecTime(UInt16 axis,double ctime);
        /// <summary>
        /// 设置轴背隙补偿值 , 用来消除轴丝杆反向间隙
        /// </summary>
        /// <param name="axis">轴号 , 从0-5</param>
        /// <param name="backhash">反向间隙值</param>
        [DllImport("move.dll", EntryPoint = "setAxisBackHash", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void setAxisBackHash(UInt16 axis, double backhash);
        /// <summary>
        /// 设置轴脉冲当量, 即每个脉冲电动台移动多少 微米或度 
        /// </summary>
        /// <param name="axis">轴号 , 从0-5</param>
        /// <param name="dangliang">脉冲当量 ,即每个脉冲电动台移动多少 微米或度</param>
        [DllImport("move.dll", EntryPoint = "setAxisDangLiang", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void setAxisDangLiang(UInt16 axis, double dangliang);
        /// <summary>
        /// 获取指定轴位置信息
        /// </summary>
        /// <param name="axis">轴号 , 从0-5</param>
        /// <returns>位置信息数据,单位:微米或度</returns>
        [DllImport("move.dll", EntryPoint = "getNowPosition", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern double getPos(UInt16 axis);
        /// <summary>
        /// 设置指定轴位置
        /// </summary>
        /// <param name="axis">轴号 , 从0-5</param>
        /// <param name="pos">位置信息数据,单位:微米或度</param>
        [DllImport("move.dll", EntryPoint = "setNowPosition", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void setPos(UInt16 axis, double pos);
        /// <summary>
        /// 单轴急停
        /// </summary>
        /// <param name="axis">轴号 , 从0-5</param>
        [DllImport("move.dll", EntryPoint = "singleImdStop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void ImdStop(UInt16 axis);
        /// <summary>
        /// 全部轴急停
        /// </summary>
        [DllImport("move.dll", EntryPoint = "AllAxisStop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void AllStop();
        /// <summary>
        /// 指定轴 相对运动
        /// </summary>
        /// <param name="axis">轴号 , 从0-5</param>
        /// <param name="len">移动距离,正数表示正向移动, 负数表示负向移动</param>
        [DllImport("move.dll", EntryPoint = "pMoveRef", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void pMoveRef(UInt16 axis, double len);
        /// <summary>
        /// 指定轴 绝对运动
        /// </summary>
        /// <param name="axis">轴号 , 从0-5</param>
        /// <param name="pos">目标位置</param>
        [DllImport("move.dll", EntryPoint = "pMoveAbs", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void pMoveAbs(UInt16 axis, double pos);
        /// <summary>
        /// 指定轴 连续运动
        /// </summary>
        /// <param name="axis">轴号 , 从0-5</param>
        /// <param name="dir">方向,1=正向移动, -1=负向移动,</param>
        [DllImport("move.dll", EntryPoint = "vMove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void vMove(UInt16 axis, Int16 dir);
        /// <summary>
        /// 设置IO口状态
        /// </summary>
        /// <param name="axis">轴号 , 从0-5</param>
        /// <param name="bitno">位号, 从0-2</param>
        /// <param name="onoff">开关状态, 0=关,1=开</param>
        [DllImport("move.dll", EntryPoint = "setIOOut", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void setIOOut(UInt16 axis, UInt16 bitno, UInt16 onoff);
        /// <summary>
        /// 获取IO口状态
        /// </summary>
        /// <param name="axis">轴号 , 从0-5</param>
        /// <param name="bitno">位号, 从0-2</param>
        /// <returns>开关状态, 0=关,1=开</returns>
        [DllImport("move.dll", EntryPoint = "getIOOut", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int getIOOut(UInt16 axis, UInt16 bitno);
        /// <summary>
        /// 等待轴停止,此函数为线程阻塞函数,在界面线程中执行会卡界面,请在工作线程中调用
        /// </summary>
        /// <param name="axis">轴号 , 从0-5</param>
        [DllImport("move.dll", EntryPoint = "waitStop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void waitStop(UInt16 axis);
        /// <summary>
        /// 释放控制卡,软件关闭时调用一次即可
        /// </summary>
        [DllImport("move.dll", EntryPoint = "CardClose", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void endClose();
    }
}
