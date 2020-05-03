using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.model.response
{
    public class ResponseInformationModel
    {
        private long id;
        private double chargeStandard;
        private string startDate;
        private int chargeDays;
        [JsonProperty ("id")]
        public long Id { get => id; set => id = value; }
        [JsonProperty("chargeStandard")]
        public double ChargeStandard { get => chargeStandard; set => chargeStandard = value; }
        [JsonProperty("startDate")]
        public string StartDate { get => startDate; set => startDate = value; }
        /// <summary>
        /// 收费天数
        /// </summary>
        [JsonProperty("chargeDays")]
        public int ChargeDays { get => chargeDays; set => chargeDays = value; }
    }
}
