using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.constants
{
    public class ConstantsValue
    {
        /// <summary>
        /// 登录URI
        /// </summary>
        public const string HTTP_LOGIN_URI = "/login";
        /// <summary>
        /// 退出URI
        /// </summary>
        public const string HTTP_LOGOUT_URI = "/logout";
        /// <summary>
        /// 添加用户URI
        /// </summary>
        public const string HTTP_ADD_USER_URI = "/sys/homeowner/add";
        /// <summary>
        /// 删除用户URI
        /// </summary>
        public const string HTTP_DELETE_USER_URI = "/sys/homeowner/del";
        /// <summary>
        /// 更新用户URI
        /// </summary>
        public const string HTTP_UPDATE_USER_URI = "/sys/homeowner/update";
        /// <summary>
        /// 更新密码URI
        /// </summary>
        public const string HTTP_RESET_PWD_URI = "/sys/user/updatePassword";
        /// <summary>
        /// 添加读卡日志
        /// </summary>
        public const string HTTP_ADD_CARD_LOG_URII = "";
        /// <summary>
        /// 查询用户URI
        /// </summary>
        public const string HTTP_SEARCH_USER_URI = "/sys/homeowner/searchHomeowner";
        /// <summary>
        /// 获取字典
        /// </summary>
        public const string HTTP_GETDICTIONARY_URI = "/sys/dictionary/getDictionary?dictionaryName=";

        /// <summary>
        /// 获取区域字典
        /// </summary>
        /// 
        public const string HTTP_GETREGION_RUI = "/sys/region/getRegion";

        /// <summary>
        /// 获取省区域字典
        /// </summary>
        public const string HTTP_GETREGION_PROVINCE_URI = "/sys/region/getProvince";
        /// <summary>
        /// 获取市地区信息
        /// </summary>
        public const string HTTP_GETREGION_CITY_URI  = "/sys/region/getCity";
        /// <summary>
        /// 获取县/区地区信息
        /// </summary>
        public const string HTTP_GETREGION_COUNTRY_URI = "/sys/region/getCountry";
        /// <summary>
        /// 获取街道地区信息
        /// </summary>
        public const string HTTP_GETREGION_STREET_URI = "/sys/region/getStreet";
        /// <summary>
        /// 获取小区域字典
        /// </summary>
        public const string HTTP_GETREGION_VILLAGE_URI = "/sys/region/getVillage";
        /// <summary>
        /// 获取用户标准信息
        /// </summary>
        public const string HTTP_INFORMATION_GET = "/sys/information/getInformation";
        /// <summary>
        /// 修改收费标准
        /// </summary>
        public const string HTTP_INFORMATION_UPDATE_CHARGE = "/sys/information/updateChargeStandard";

    }
}
