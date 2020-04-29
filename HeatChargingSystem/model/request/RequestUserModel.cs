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
    public class RequestUserModel
    {
        /// <summary>
        /// 阀门序列号
        /// </summary>
        private string controllerCode { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        private string name { get; set; }
        /// <summary>
        /// 缴费状态
        /// </summary>
        private string status { get; set; }
    }
}
