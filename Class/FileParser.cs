using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using DBOperation.Resource;



namespace DBOperation.Class
{
   public class FileParser
    {
       public string filePath;
       public  FileParser (string fileName)
       {
           if (!File.Exists(fileName))
           {
              // throw (new ApplicationException("文件不存在"));
               MessageBox.Show(fileName + "不存在");
           }
           this.filePath = fileName;
       }
       #region  解析弹道文件  

       public List<TrajBean> TrajFileParser()
       {

           var trajLst = new List<TrajBean>();
           try
           {
               using (var sr = new FileStream(filePath, FileMode.Open))
               {
                   var reader = new StreamReader(sr);
                   int imgCount = Int32.Parse(reader.ReadLine());
                   for (int index = 0; index < imgCount;index++)
                   {
                       var trajBean = new TrajBean();
                       trajBean.TrajIndex = index;
                       var line = reader.ReadLine();
                       string[] parts = line.Split(',');
                       trajBean.TrajHeight = Double.Parse(parts[4]);
                    //   trajBean.TrajLongAndLat = new Point(Double.Parse(parts[3]), Double.Parse(parts[2]));
                       trajBean.TrajLong = Double.Parse(parts[3]);
                       trajBean.TrajLat = Double.Parse(parts[2]);
                       // trajBean.PoseAngel = new List<double> { Double.Parse(parts[11]), Double.Parse(parts[12]), Double.Parse(parts[13]) }; ;
                        trajBean.ScrollAng = Double.Parse(parts[11]);
                        trajBean.PitchAng = Double.Parse(parts[12]);
                        trajBean.YawAng = Double.Parse(parts[13]);
                       trajLst.Add(trajBean);

                   }
                  // var poseList = new List<double>();
                  // //读取第一行弹道
                  // var firstLine = reader.ReadLine();
                  // var subfirstLine = firstLine.Split(',');
                  // double maxHeight = Double.Parse(subfirstLine[4]);
                  // double minHeight = 0;
                  // var originPoint=new Point(Double.Parse(subfirstLine[3]), Double.Parse(subfirstLine[2]));
                  // trajBean.TrajLongAndLat = new List<Point>();
                  // trajBean.TrajLongAndLat.Add(originPoint);
                  // //trajBean.TrajHeight = new Point(Double.Parse(subfirstLine[4]), 0);
                  //// trajBean.TrajLongAndLat.Add(new Point(Double.Parse(subfirstLine[3]), Double.Parse(subfirstLine[2])));
                  //trajBean.PoseAngel = new List<double> { Double.Parse(subfirstLine[11]), Double.Parse(subfirstLine[12]), Double.Parse(subfirstLine[13]) };

                  // //如果存在多条弹道  则读取最后一条弹道
                  // if (trajBean.TrajCount > 1)
                  // {
                  //     for (int index = 1; index < trajBean.TrajCount - 1; index++) reader.ReadLine();
                  //     var line = reader.ReadLine();
                  //     string[] parts = line.Split(',');
                  //     minHeight = Double.Parse(parts[4]);
                  //     trajBean.TrajLongAndLat.Add(new Point(Double.Parse(parts[3]), Double.Parse(parts[2])));

                  // }

                  // trajBean.TrajHeightRange = new Point(maxHeight, minHeight);

               
               }
           }
           catch (System.Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }
          
           return trajLst;
       }
       #endregion
        #region 解析天候文件
        #endregion
    }
}
