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
    class RaceAction : IAction
    {
        [JsonProperty]
        public int Turn { get; set; }
        [JsonProperty]
        public RaceGrade RaceGrade { get; set; }
        [JsonProperty]
        public int Rank { get; set; }
    }
}
