using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Xml;
using System.Windows;
using DBOperation.Resource;
namespace DBOperation.Class
{
    public class FileStore
    {
        private string initialPath;

        public FileStore()
        {
            string xmlPath = @"D:\root\DBConfig.xml";
            if (!File.Exists(xmlPath))
            {
                MessageBox.Show("文件不存在");
                return;

            }
            
          XmlDocument cfgDoc = new XmlDocument();
            cfgDoc.Load(xmlPath);
            this.initialPath = cfgDoc.SelectSingleNode("DBConfig//RootDir").InnerText;
            if (initialPath == null || initialPath.Equals("")) MessageBox.Show("未读取配置文件！");
        }
        public FileStore(string rootPath)
        {
            if (rootPath == null || rootPath.Equals(""))
            {
            if (!File.Exists("DBConfig.xml")) return;
            XmlDocument cfgDoc = new XmlDocument();
            cfgDoc.Load("DBConfig.xml");
            this.initialPath = cfgDoc.SelectSingleNode("DBConfig//RootDir").InnerText;
            if (initialPath == null || initialPath.Equals("")) MessageBox.Show("未读取配置文件！");
            }
            else
            {
                this.initialPath = rootPath;
            }
       }
        public string StoreImg(List<string> filePath)
        {
            var dt = DateTime.Now.ToString("yyMMddHHmmss");
            string relativePath = "Resource\\Img\\" + dt;
            if (!Directory.Exists(initialPath + relativePath + "\\")) Directory.CreateDirectory(initialPath + relativePath + "\\");
            var dstPath = new List<string>();
            try
            {

                foreach (var subfile in filePath)
                {
                    var subparts = subfile.Split('\\');
                    var endname = subparts.Last();
                    var destfilePath = initialPath + relativePath + "\\" + endname;                  
                    dstPath.Add(destfilePath);
                    File.Copy(subfile, destfilePath);
                   
                   
                }
                var lstpath = initialPath + relativePath + "\\" + dt + ".lst";
                using (var fs = new FileStream(lstpath, FileMode.Create, FileAccess.Write))
                {
                    var writer = new StreamWriter(fs);
                    writer.WriteLine(dstPath.Count);
                    int index = 0;
                    dstPath.ForEach(subPath =>
                    {
                        writer.WriteLine("{0:00000000},{1}", index++, subPath);
                    });
                    writer.Close();
                }
                return lstpath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()+"move image file failed");
            }
            

            return null;
        }

        /// <summary>
        /// 对于相机文件和弹道文件的存储
        /// </summary>
        /// <param name="srcFile"></param>
        /// <param name="flag">0代表 相机文件 1 代表 图像文件</param>
        public string StoreFile(string srcFile, int flag)
        {
            var dt = DateTime.Now.ToString("yyMMddHHmmss");
            string relativePath = null;
            switch (flag)
            {
                case 0:
                    relativePath = "Resource\\Camera\\" + dt;
                    break;
                case 1:
                    relativePath = "Resource\\Traj\\" + dt;
                    break;
            }

            try
            {

                var subparts = srcFile.Split('\\');
                var endname = subparts.Last();
                var destdir = initialPath + relativePath + "\\";
                var dstpath = destdir + endname;
                if (!Directory.Exists(destdir))
                { Directory.CreateDirectory(destdir); }
                File.Copy(srcFile, dstpath);

                return dstpath;


            }
            catch (System.Exception ex)
            {
                MessageBox.Show("move camera file failed");
            }
            return null;
        }
        public void StoreCameraFile(string srcFile, int flag)
        {
            var dt = DateTime.Now.ToString("yMMddHHmmss");
            string reletivePath = "Resource\\";
            switch (flag)
            {
                case 0:
                    reletivePath = "Resource\\Camera\\";
                    break;
                case 1:
                    reletivePath = "Resource\\Traj\\";
                    break;
            }
            if (!Directory.Exists(initialPath + reletivePath)) Directory.CreateDirectory(initialPath + reletivePath);
            var parts = srcFile.Split('\\');
            var endname = parts.Last();
            var dstPah = initialPath + reletivePath + dt + "_" + endname;
            try
            {
                File.Copy(srcFile, dstPah);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n" + "Move Camera file failed");

            }
        }
        public void GetCameraLst()
        {
            var commBean = Application.Current.TryFindResource("commonBean");
            string dstFolder = initialPath + "Resource\\Camera\\";
            var fileLst= Directory.GetFiles(dstFolder,"*.para");
            
        }
        public string SetCamera(CameraBean camBean)
        {
            var dt = DateTime.Now.ToString("yyMMddHHmmss");
            var reletivePath = "Resource\\Camera\\";

            var fileName = initialPath + reletivePath + dt + "_camera.para";
            if (!File.Exists(fileName)) File.Create(fileName);
             fileName=fileName.Replace("\\","\\\\");
            camBean.WriteCfg(fileName);
            return fileName;
        }
        public string SetTraj(List<TrajBean> trajLst)
        {
            var dt = DateTime.Now.ToString("yyMMddHHmmss");
            var reletivePath = "Resource\\Traj\\";
            var fileName = initialPath + reletivePath + dt + "_traj.para";
            var trBeanW = new BeanWiter(fileName);
            trBeanW.WriteTraj(trajLst);
            return fileName; 
        }
    }
}
