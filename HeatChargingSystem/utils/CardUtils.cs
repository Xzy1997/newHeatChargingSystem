using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.utils
{
    public class CardUtils
    {
        [DllImport("kernel32.dll")]
        static extern void Sleep(int dwMilliseconds);

        [DllImport("MasterRD.dll")]
        static extern int lib_ver(ref uint pVer);

        /// <summary>
        /// 串行口初始化
        /// </summary>
        /// <param name="port"></param>
        /// <param name="baud"></param>
        /// <returns></returns>
        [DllImport("MasterRD.dll")]
        static extern int rf_init_com(int port, int baud);

        /// <summary>
        /// 关闭串行口
        /// </summary>
        /// <returns></returns>
        [DllImport("MasterRD.dll")]
        static extern int rf_ClosePort();

        /// <summary>
        /// 控制蜂鸣器响
        /// </summary>
        /// <param name="icdev">通讯设备标识</param>
        /// <param name="delay">蜂鸣时间，单位毫秒</param>
        /// <returns></returns>
        [DllImport("MasterRD.dll")]
        static extern int rf_beep(short icdev, byte delay);

        /// <summary>
        /// 设置LED指示灯颜色
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="Ledcolor">0：LED熄灭；1：蓝光；2：红光</param>
        /// <returns>成功返回0</returns>
        [DllImport("MasterRD.dll")]
        static extern int rf_light(short icdev, byte Ledcolor);

        /// <summary>
        /// 设置读写卡器天线状态
        /// </summary>
        /// <param name="icdev"></param>
        /// <param name="mode">0x00关闭天线，0x01开启天线</param>
        /// <returns></returns>
        [DllImport("MasterRD.dll")]
        static extern int rf_antenna_sta(short icdev, byte mode);
        //[DllImport("MasterRD.dll")]
        //static extern int rf_cos_command(short icdev, by)

        [DllImport("MasterRD.dll")]
        static extern int rf_init_type(short icdev, byte type);
        /// <summary>
        /// 寻Type_A卡
        /// </summary>
        /// <param name="icdev">通讯设备标识符</param>
        /// <param name="mode">寻卡模式；0x26寻未进入休眠状态的卡；0x52寻所有状态的卡</param>
        /// <param name="pTagType">返回卡类型值，0x4400；0x0400；0x0200;0x4403;0x0800;0x0403;0x0033;</param>
        /// <returns>成功0</returns>
        [DllImport("MasterRD.dll")]
        static extern int rf_request(short icdev, byte mode, ref ushort pTagType);

        [DllImport("MasterRD.dll")]
        static extern int rf_anticoll(short icdev, byte bcnt, IntPtr pSnr, ref byte pRLength);

        [DllImport("MasterRD.dll")]
        static extern int rf_select(short icdev, IntPtr pSnr, byte srcLen, ref sbyte Size);

        [DllImport("MasterRD.dll")]
        static extern int rf_halt(short icdev);

        [DllImport("MasterRD.dll")]
        static extern int rf_M1_authentication2(short icdev, byte mode, byte secnr, IntPtr key);

        [DllImport("MasterRD.dll")]
        static extern int rf_M1_initval(short icdev, byte adr, Int32 value);

        [DllImport("MasterRD.dll")]
        static extern int rf_M1_increment(short icdev, byte adr, Int32 value);

        [DllImport("MasterRD.dll")]
        static extern int rf_M1_decrement(short icdev, byte adr, Int32 value);

        [DllImport("MasterRD.dll")]
        static extern int rf_M1_readval(short icdev, byte adr, ref Int32 pValue);

        [DllImport("MasterRD.dll")]
        static extern int rf_M1_read(short icdev, byte adr, IntPtr pData, ref byte pLen);

        [DllImport("MasterRD.dll")]
        static extern int rf_M1_write(short icdev, byte adr, IntPtr pData);

        [DllImport("MasterRD.dll")]
        static extern int rf_ul_select(short icdev, IntPtr pSnr, ref byte pRLength);

        [DllImport("MasterRD.dll")]
        static extern int rf_ul_write(short icdev, byte page, IntPtr pData);
    }
}
