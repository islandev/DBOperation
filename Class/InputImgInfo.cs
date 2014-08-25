using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace DBOperation.Class
{
    public class InputImgInfo
    {
        public int index { get; set; }
        public string filePath { get; set; }       
        public int resolutionX { get; set; }
        public int resolutionY { get; set; }
        public double imgSize { get; set; }
        public BitmapSource imgSource { get; set; } 
    }
}
