using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmainD.Models
{
    class Race : IAction
    {
        public int Turn { get; set; }
        public RaceGrade RaceGrade { get; set; }
        public int Rank { get; set; }
    }

    enum RaceGrade
    {
        URA,
        G1,
        G2,
        G3,
        Open,
        Debut
    }
}
