using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmainD.Data;

namespace UmainD.Models
{
    class RaceAction : IAction
    {
        public int Turn { get; set; }
        public RaceGrade RaceGrade { get; set; }
        public int Rank { get; set; }
    }
}
