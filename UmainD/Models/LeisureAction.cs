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
    class LeisureAction : IAction
    {
        [JsonProperty]
        public int Turn { get; set; }
        [JsonProperty]
        public LeisureKind Kind { get; set; }
    }
}
