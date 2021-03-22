using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UmainD.Converters
{
    class TurnToMonthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var turn = value as int? ?? 0;

            switch (turn)
            {
                case int i when i == 0:
                    return "";
                case int i when i <= 72:
                    return $"{GetMonth(turn)}月";
                case int i when i <= 78:
                    return "Final";
                default:
                    return "育成完了";
            }
        }

        private static int GetMonth(int turn)
        {
            int result;

            if (turn % 24 == 0)
            {
                result = 12;
            }
            else if (turn % 2 == 0)
            {
                result = (turn % 24) / 2;
            }
            else
            {
                result = (turn % 24) / 2 + 1;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
