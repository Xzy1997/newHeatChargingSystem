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
    }
}
