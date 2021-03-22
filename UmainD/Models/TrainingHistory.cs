using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmainD.Models
{
    class TrainingHistory : BindingBase
    {
        private int speedCount = 0;
        public int SpeedCount
        {
            get { return speedCount; }
            set
            {
                if (value != speedCount)
                {
                    speedCount = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int staminaCount = 0;
        public int StaminaCount
        {
            get { return staminaCount; }
            set
            {
                if (value != staminaCount)
                {
                    staminaCount = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int powerCount = 0;
        public int PowerCount
        {
            get { return powerCount; }
            set
            {
                if (value != powerCount)
                {
                    powerCount = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int gutsCount = 0;
        public int GutsCount
        {
            get { return gutsCount; }
            set
            {
                if (value != gutsCount)
                {
                    gutsCount = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int wiseCount = 0;
        public int WiseCount
        {
            get { return wiseCount; }
            set
            {
                if (value != wiseCount)
                {
                    wiseCount = value;
                    RaisePropertyChanged();
                }
            }
        }

        public void Reset()
        {
            SpeedCount = 0;
            StaminaCount = 0;
            PowerCount = 0;
            GutsCount = 0;
            WiseCount = 0;
        }
    }
}
