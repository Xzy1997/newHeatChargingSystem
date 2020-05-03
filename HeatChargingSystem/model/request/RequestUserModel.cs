using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.model.request
{
    /// <summary>
    /// 用户查询参数
    /// </summary>
    public class RequestUserModel : ObservableObject
    {
        public RequestUserModel()
        {
        }
        /// <summary>
        /// 阀门序列号
        /// </summary>
        private string controllerCode;
        /// <summary>
        /// 用户名
        /// </summary>
        private string name;
        /// <summary>
        /// 缴费状态
        /// </summary>
        private int payStatus;
        /// <summary>
        /// /阀门序列号
        /// </summary>
        [JsonProperty("controllerCode")]
        public string ControllerCode { get => controllerCode; set => controllerCode = value; }
        /// <summary>
        /// 用户名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 缴费状态
        /// </summary>
        [JsonProperty("status")]
        public int PayStatus { get => payStatus; set => payStatus = value; }
    }
}
