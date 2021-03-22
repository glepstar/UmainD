using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UmainD.Converters
{
    class TurnToHalfConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var turn = value as int? ?? 0;

            if(turn == 0)
            {
                return "";
            }

            if(turn <= 72)
            {
                return (turn % 2 != 0) ? "前半" : "後半";
            }

            switch (turn)
            {
                case 73:
                    return "予選前";
                case 74:
                    return "予選";
                case 75:
                    return "準決勝前";
                case 76:
                    return "準決勝";
                case 77:
                    return "決勝前";
                case 78:
                    return "決勝";
                default:
                    return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
