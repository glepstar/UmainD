using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmainD.Data;

namespace UmainD.Models
{
    class TrainingAction : IAction
    {
        public int Turn { get; set; }
        public TrainingKind Kind { get; set; }
        public TrainingResult Result { get; set; }
        public bool IsFriendlyTag { get; set; }
    }
}
