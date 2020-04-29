using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.model.response
{
    public class BaseResponseModel
    {
        public string code { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
    }
}
