using GalaSoft.MvvmLight;
using HeatChargingSystem.model.Validate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.model.response
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class ResponseUserInfoModel : ValidateModelBase
    {

        private bool isChecked;

        /// <summary>
        /// C端用户表Id
        /// </summary>
        private string id;
        /// <summary>
        /// 姓名
        /// </summary>
        private string name;
        /// <summary>
        /// 网络用户
        /// </summary>
        private string hourseCode;
        /// <summary>
        /// 用户类型（00系统用户）
        /// </summary>
        private string userType;
        /// <summary>
        /// 供暖面积
        /// </summary>
        private string area;
        /// <summary>
        /// 省
        /// </summary>
        private string provice;
        /// <summary>
        /// 市
        /// </summary>
        private string city;
        /// <summary>
        /// 县/区
        /// </summary>
        private string county;
        /// <summary>
        /// 街道
        /// </summary>
        private string street;
        /// <summary>
        /// 小区
        /// </summary>
        private string village;
        /// <summary>
        /// 详细地址-楼号
        /// </summary>
        private string build;
        /// <summary>
        /// 详细地址-单元
        /// </summary>
        private string unit;
        /// <summary>
        /// 详细地址-室
        /// </summary>
        private string room;
        /// <summary>
        /// 阀门序列号
        /// </summary>
        private string controllerCode;
        /// <summary>
        /// 阀门类型
        /// </summary>
        private string controllerType;
        /// <summary>
        /// 阀门类型名称
        /// </summary>
        private string controllerTypeName;
        /// <summary>
        /// 创建时间
        /// </summary>
        private string createDate;
        /// <summary>
        /// 详细地址
        /// </summary>
        private string address;
        /// <summary>
        /// 阀门开度
        /// </summary>
        private string openPecent;
        /// <summary>
        /// 阀门缴费状态,0：未缴费，1：已经缴费，2：不需要
        /// </summary>
        private int paySstatus;
        /// <summary>
        /// 联系方式
        /// </summary>
        private string phone;
        private string heatingStations;

        /// <summary>
        /// 用户id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get => id; set => Set(ref id, value); }
        /// <summary>
        /// 姓名
        /// </summary>
        [JsonProperty("name")]
        [Required(ErrorMessage ="用户名必须输入")]
        public string Name { get => name; set => Set(ref name, value);  }
        /// <summary>
        /// 网络户口
        /// </summary>
        [JsonProperty("hourseCode")]
        public string HourseCode { get => hourseCode; set => Set(ref hourseCode, value); }
        /// <summary>
        /// 用户类型，1：民用，2：商用，3：公建，4：其他类型
        /// </summary>
        [JsonProperty("userType")]
        [Required]
        public string UserType { get => userType; set => Set(ref userType, value); }
        /// <summary>
        /// 供暖面积
        /// </summary>
        [Required]
        [JsonProperty("area")]
        public string Area { get => area; set => Set(ref area, value); }
        /// <summary>
        /// 省
        /// </summary>
        [JsonProperty("provice")]
        [Required]
        public string Provice { get => provice; set => Set(ref provice, value); }
        /// <summary>
        /// 市
        /// </summary>
        [JsonProperty("city")]
        [Required]
        public string City { get => city; set => Set(ref city, value); }
        /// <summary>
        /// 县/区
        /// </summary>
        [JsonProperty("county")]
        [Required]
        public string County { get => county; set => Set(ref county, value); }
        /// <summary>
        /// 街道
        /// </summary>
        [JsonProperty("street")]
        public string Street { get => street; set => Set(ref street, value); }
        /// <summary>
        /// 小区
        /// </summary>
        [JsonProperty("village")]
        public string Village { get => village; set => Set(ref village, value); }
        /// <summary>
        /// 详细地址-楼号
        /// </summary>
        [JsonProperty("build")]
        [Required]
        [RegularExpression(@"^(-)?\d+(\.\d+)?$", ErrorMessage = "请填写数字")]
        public string Build { get => build; set => Set(ref build, value); }
        /// <summary>
        /// 详细地址-单元
        /// </summary>
        [JsonProperty("unit")]
        [Required]
        [RegularExpression(@"^(-)?\d+(\.\d+)?$", ErrorMessage = "请填写数字")]
        public string Unit { get => unit; set => Set(ref unit, value); }
        /// <summary>
        /// 详细地址-室
        /// </summary>
        [JsonProperty("room")]
        [Required]
        [RegularExpression(@"^(-)?\d+(\.\d+)?$", ErrorMessage = "请填写数字")]
        public string Room { get => room; set => Set(ref room, value); }
        /// <summary>
        /// 阀门序列号
        /// </summary>
        [JsonProperty("controllerCode")]
        [Required]
        public string ControllerCode { get => controllerCode; set => Set(ref controllerCode, value); }
        /// <summary>
        /// 阀门类型
        /// </summary>
        [JsonProperty("controllerType")]
        [Required]
        public string ControllerType { get => controllerType; set => Set(ref controllerType, value); }
        /// <summary>
        /// 阀门类型名称
        /// </summary>
        [JsonProperty("controllerTypeName")]
        public string ControllerTypeName { get => controllerTypeName; set => Set(ref controllerTypeName, value); }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("createDate")]
        public string CreateDate { get => createDate; set => Set(ref createDate, value); }
        /// <summary>
        /// 详细地址
        /// </summary>
        [JsonProperty("address")]
        public string Address { get => address; set => Set(ref address, value); }
        /// <summary>
        /// 阀门开度
        /// </summary>
        [JsonProperty("openPecent")]
        public string OpenPecent { get => openPecent; set => Set(ref openPecent, value); }
        /// <summary>
        /// 缴费状态
        /// </summary>
        [JsonProperty("paySstatus")]
        public int PaySstatus { get => paySstatus; set => Set(ref paySstatus, value); }
        /// <summary>
        /// 联系方式
        /// </summary>
        [Required]
        [RegularExpression(@"^[-]?[1-9]{8,11}\d*$|^[0]{1}$", ErrorMessage = "用户电话必须为8-11位的数值.")]
        [JsonProperty("phone")]
        public string Phone { get => phone; set => Set(ref phone, value); }
        /// <summary>
        /// 供热站
        /// </summary>
        [JsonProperty("heatingStations")]
        public string HeatingStations { get => heatingStations; set => Set(ref heatingStations, value); }
        [JsonIgnore]
        public bool IsChecked { get => isChecked; set => Set(ref isChecked, value); }
    }
    
}
