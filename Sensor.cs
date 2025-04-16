using System.Runtime.InteropServices;

namespace WindowsFormsApp3
{
    internal class Sensor
    {
        /// <summary>
        /// 传感器初始化, 根据用户提供的串口号检查传感器端口, 不成功则自动识别真实串口号
        /// </summary>
        /// <param name="comName">用户提供的串口号</param>
        /// <returns>初始化状态,小于0=不成功, 大于0=成功</returns>
        [DllImport("sensor.dll", EntryPoint = "sensorInit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Init(int comName);
        /// <summary>
        /// 获取识别到的真实串口号
        /// </summary>
        /// <returns>真实串口号</returns>
        [DllImport("sensor.dll", EntryPoint = "getComPort", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int getComName();
        /// <summary>
        /// 获取指定通道传感器值
        /// </summary>
        /// <param name="channel">通道号</param>
        /// <returns>传感器值</returns>
        [DllImport("sensor.dll", EntryPoint = "getSensor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int getSensor(int channel);
        /// <summary>
        /// 设置指定通道归零值
        /// </summary>
        /// <param name="channel">通道号</param>
        /// <param name="zero">归零值</param>
        [DllImport("sensor.dll", EntryPoint = "setZero", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void setZero(int channel, int zero);
        /// <summary>
        /// 释放传感器
        /// </summary>
        [DllImport("sensor.dll", EntryPoint = "closeSensor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void endClose();

    }
}
