using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmainD.Models
{
    class Leisure : IAction
    {
        public int Turn { get; set; }
        public LeisureKind Kind { get; set; }
    }

    enum LeisureKind
    {
        Holiday,
        Date,
        Infirmary
    }
}
