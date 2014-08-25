using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace DBOperation.Converter
{
 public   class TargetTypeconverter:IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var index = (int)value;
            switch (index)
            {
                case 0:
                    return "飞机";
                case 1:
                    return "掩蔽库";
                case 2:
                    return "油库";
                case 3:
                    return "建筑";
                default:
                    return "木哈哈，彩蛋有木有";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
