using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmainD.Models
{
    [JsonObject]
    interface IAction
    {
        [JsonProperty]
        int Turn { get; set; }
    }
}
