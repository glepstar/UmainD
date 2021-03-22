using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UmainD.Converters
{
    class TurnToRankConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var turn = value as int? ?? 0;

            switch (turn)
            {
                case int i when i == 0:
                    return "";
                case int i when i <= 72:
                    return GetRank(turn);
                case int i when i <= 78:
                    return "URA";
                default:
                    return "";
            }
        }

        private static object GetRank(int turn)
        {
            switch ((turn - 1) / 24)
            {
                case 0:
                    return "ジュニア級";
                case 1:
                    return "クラシック級";
                case 2:
                    return "シニア級";
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
