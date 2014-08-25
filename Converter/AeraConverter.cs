using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace DBOperation.Converter
{
   public class AeraConverter:IValueConverter
    {
        #region IValueConverter 成员

       object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var index = (int)value;
            switch (index)
            {
                case 0:
                    return "宜昌";
                case 1:
                    return "敦煌";
                default :
                    return "the unkown place";

          }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
