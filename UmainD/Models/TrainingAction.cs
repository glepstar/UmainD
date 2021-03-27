using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmainD.Data;

namespace UmainD.Models
{
    [JsonObject]
    class TrainingAction : IAction
    {
        [JsonProperty]
        public int Turn { get; set; }
        [JsonProperty]
        public TrainingKind Kind { get; set; }
        [JsonProperty]
        public TrainingResult Result { get; set; }
        [JsonProperty]
        public bool IsFriendlyTag { get; set; }
    }
}
