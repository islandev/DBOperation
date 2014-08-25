using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBOperation.Class
{
    public class DateTimeRange
    {
        private DateTime startTime;
        private DateTime endTime;
        public DateTimeRange(DateTime st,DateTime et)
        {
            this.startTime = st;
            this.endTime = et;
        }
        public bool IsInRange(DateTime nowTime)
        {
            var context = BaseDBEntities.GetContext();
            var dateLst = (from s in context.tb_Base_Weather select s.AVdate).ToList();
            var timeLst = (from s in context.tb_Base_Weather select s.AVtime).ToList();
            var dtStringLst = new List<string>();
            int index = 0;
            dateLst.ForEach(dateString =>
                {
                    dtStringLst.Add( dateString+" "+timeLst[index++]);
                });
            var dtlst = new List<DateTime>();
            dtStringLst.ForEach(dtString =>
            {
                Convert.ToDateTime(dtString);
            });
            return false;
        }
    }
}
