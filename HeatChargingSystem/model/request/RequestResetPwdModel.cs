using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.model.request
{
    public class RequestResetPwdModel
    {
        private string oldPassword;
        private string newPassword;

        [JsonProperty ("oldPassword")]
        public string OldPassword { get => oldPassword; set => oldPassword = value; }
        [JsonProperty("newPassword")]
        public string NewPassword { get => newPassword; set => newPassword = value; }
    }
}
