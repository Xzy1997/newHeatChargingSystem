using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.model
{
    public class ComboBoxModel : ObservableObject
    {
        private int id;
        private int code;
        private string name;
        private int pid;

        [JsonProperty ("code")]
        public int Code { get => code; set => Set(ref code, value); }
        [JsonProperty("name")]

        public string Name { get => name; set => Set(ref name, value); }
        [JsonProperty ("pid")]
        public int Pid { get => pid; set => Set(ref pid, value); }
        public int Id { get => id; set => Set(ref id,value); }
    }
}
