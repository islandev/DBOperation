using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace DBOperation.Converter
{
    class ImgTypeconverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var imgType = value.ToString();
            switch (imgType)
            {
                case "挂飞":
                    return 0;
                case "实飞":
                    return 1;
                case "卫星":
                    return 2;

 


            }
            return null;

            
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var imgTypeIndex = Int32.Parse(value.ToString());
            switch (imgTypeIndex)
            {
                case 0:
                    return "挂飞";
                case 1:
                    return "实飞";
                case 2:
                    return "卫星  ";
            }
            return null;
        }
    }
}
