using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace DBOperation.Converter
{
    public class CloudTypeConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var stringVal = (string)value;
            switch (stringVal)
            {
                case "无云":
                    return 0;
                case "积云":
                    return 1;
                case "高层云":
                    return 2;
                case "层云":
                    return 3;
                default:
                    return -1;

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((int)value)
            {
                case 0:
                    return "无云";
                case 1:
                    return "积云";
                case 2:
                    return "高层云";
                case 3:
                    return "层云";
                default:
                    return "彩蛋云";
            }

        }

        #endregion
    }
}
