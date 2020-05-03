using HeatChargingSystem.utils;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem
{
    public class AppConfigMoel
    {
        public static string URL = AppConfigUtils.ReadSetting("APP_URI");
        public static string token = string.Empty;
        public static string ComPortName = AppConfigUtils.ReadSetting("Com_Port");

        /// <summary>
        /// 清除缓存
        /// </summary>
        public static void ClearCache()
        {
            token = string.Empty;
        }
    }
}
