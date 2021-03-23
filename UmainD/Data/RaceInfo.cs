using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmainD.Models;

namespace UmainD.Data
{
    [JsonObject]
    public class RaceInfo
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public RaceGrade Grade { get; set; }

        [JsonProperty]
        public string Course { get; set; }

        [JsonProperty]
        public string Turf { get; set; }

        [JsonProperty]
        public int Distance { get; set; }

        [JsonProperty]
        public string Direction { get; set; }

        [JsonProperty]
        public int Fun { get; set; }

        [JsonProperty]
        public int[] Turn { get; set; }
    }
}
