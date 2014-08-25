using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace DBOperation.Converter
{
   [ValueConversion(typeof(int),typeof(string))] 
    public   class WeatherTypeConverter:IValueConverter
    {
      

       public System.Object Convert(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture)
       {
           var src = (string)value;
           switch (src)
           {
               case "晴":
                   return 0;
               case "阴":
                   return 1;
               case "毛毛雨":
                   return 2;
               case "小雨":
                   return 3;
               case "中雨":
                   return 4;
               case "薄雾":
                   return 5;
               case "中雾":
                   return 6;
               case "浓雾":
                   return 7;
               case "浮尘":
                   return 8;
               case "扬沙":
                   return 9;
               default: return -1;
           }
       }
       public System.Object ConvertBack(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture)
       {
           var index = (int)value;


           switch (index)
           {
               case 0:
                   return "晴";
               case 1:
                   return "阴";
               case 2:
                   return "毛毛雨";
               case 3:
                   return "小雨";
               case 4:
                   return "中雨";
               case 5:
                   return "薄雾";
               case 6:
                   return "中雾";
               case 7:
                   return "浓雾";
               case 8:
                   return "浮尘";
               case 9:
                   return "扬沙";
               default:
                   return "";

           }
       }
    }
}
