using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBOperation.Resource;

namespace DBOperation.Class
{
    public static class LoadDefaultData
    {
        private static BaseDBEntities Context = null;
        static LoadDefaultData()
        {
            Context = BaseDBEntities.GetContext();
        }

        public static List<tb_Base_Camera>  LoadDefaultCamera()
        {
            var camlst = from cam in Context.tb_Base_Camera where cam.IsDefault == 1 select cam;
            return camlst.ToList<tb_Base_Camera>();
        }
        public static List<tb_Base_Weather>  LoadDefaultWeather()
        {
            var wheatherLst = from wheather in Context.tb_Base_Weather where wheather.IsDefault == 1 select wheather;
            return wheatherLst.ToList<tb_Base_Weather>();

        }
    }
}
