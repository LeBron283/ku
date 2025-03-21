using System;
using System.Runtime.InteropServices;

namespace WindowsFormsApp3
{
    internal class PM
    {
        /// <summary>
        /// 功率计初始化, 根据用户提供的串口号检查传感器端口, 不成功则自动识别真实串口号
        /// </summary>
        /// <param name="comName">串口号</param>
        /// <returns>初始化状态,小于0=不成功, 大于0=成功</returns>
        [DllImport("power.dll", EntryPoint = "comInit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Init(int comName);
        /// <summary>
        /// 获取识别到的真实串口号
        /// </summary>
        /// <returns>真实串口号</returns>
        [DllImport("power.dll", EntryPoint = "getComName", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int getComName();
        /// <summary>
        /// 获取功率计值, 实时获取, 可以用在连续实时显示方面
        /// </summary>
        /// <param name="channel">通道号,单通道只有通道1</param>
        /// <returns>功率计值</returns>
        [DllImport("power.dll", EntryPoint = "getPower", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern double getPower(int channel);
        /// <summary>
        /// 强制等待更新一次功率值,并返回功率计值, 该函数应该各个微调算法中使用
        /// </summary>
        /// <param name="channel">通道号,单通道只有通道1</param>
        /// <returns>功率计值</returns>
        [DllImport("power.dll", EntryPoint = "getPowerEx", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern double getPowerEx(int channel);
        /// <summary>
        /// 设置归零值
        /// </summary>
        /// <param name="channel">通道号</param>
        /// <param name="zero">归零值</param>
        [DllImport("power.dll", EntryPoint = "setZero", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void setZero(int channel, double zero);
        /// <summary>
        /// 设置波长
        /// </summary>
        /// <param name="channel">通道号</param>
        /// <param name="WaveLength">波长:1310,1550</param>
        [DllImport("power.dll", EntryPoint = "selWaveLength", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void selWaveLength(int channel, int WaveLength);
        /// <summary>
        /// 释放功率计
        /// </summary>
        [DllImport("power.dll", EntryPoint = "endClose", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void endClose();

    }
}
