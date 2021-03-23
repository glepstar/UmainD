using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmainD.Data;

namespace UmainD.Models
{
    class LeisureAction : IAction
    {
        public int Turn { get; set; }
        public LeisureKind Kind { get; set; }
    }
}
