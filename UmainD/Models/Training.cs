using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmainD.Models
{
    class Training : IAction
    {
        public int Turn { get; set; }
        public TrainingKind Kind { get; set; }
        public TrainingResult Result { get; set; }
        public bool IsFriendlyTag { get; set; }
    }

    enum TrainingKind
    {
        Speed,
        Stamina,
        Power,
        Guts,
        Wise
    }

    enum TrainingResult
    {
        Success,
        Failed
    }
}
