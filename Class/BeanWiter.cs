using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBOperation.Resource;
using System.IO;


namespace DBOperation.Class
{
    public class BeanWiter
    {
        private string filePath;
        public BeanWiter(string fileName)
        {
            this.filePath = fileName;
        }
        public void  WriteTraj(List<TrajBean> trajLst)
        {
            
            try
            {
                using (var sr = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    var writer = new StreamWriter(sr);
                    writer.WriteLine(trajLst.Count);
                    int index = 0;                    
                    trajLst.ForEach(trajBean =>
                        {
                            writer.WriteLine("{0:00000000},{1}", index++, trajBean.ReadToString());
                        });
                    writer.Close();
                }
            }
            catch (System.Exception ex)
            {
            	
            }

        }
       
    }
}
