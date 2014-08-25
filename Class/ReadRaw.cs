using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.IO;
using VSLangProj;
 



namespace DBOperation.Class
{
    public  class ReadRaw
    {
        private string fileName;
        public  ReadRaw(string filePath)
        {
            this.fileName = filePath;
          
        }
        public InputImgInfo ShowRaw()
        {
            var imgInfo = new InputImgInfo();
            var sr = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            {

                var fattr = File.GetAttributes(fileName);
                
                var headData = new byte[42];
                sr.Read(headData, 0, 42);
                var Width = BitConverter.ToUInt16(headData, 4);
                var Height = BitConverter.ToUInt16(headData, 6);
                var pixelPerByte = headData[8];
                var dataShortInt= new ushort[Width * Height ];
                var rawData = new byte[Width * Height * 4];
                sr.Read(rawData, 0, Height * Width *4 );
                var num = Width * Height;
                for (int i = 0; i < num;i++ )
                {

                    dataShortInt[i] = Convert.ToUInt16((BitConverter.ToSingle(rawData, i * 4)));
                      
                }
                var rawStride = (Width * System.Windows.Media.PixelFormats.Gray16.BitsPerPixel + 7) / 8;
                imgInfo.imgSource = BitmapSource.Create(Width, Height, 96, 96, System.Windows.Media.PixelFormats.Gray16, null, dataShortInt, rawStride);
                GC.Collect();
                imgInfo.resolutionX = Width;
                imgInfo.resolutionY = Height;
                imgInfo.filePath = fileName;
                
                
            }
            return imgInfo;
        }
        public InputImgInfo ShowJpg()
        {
            var imgInfo = new InputImgInfo();
            var imageStreamSource = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            {
                var decoder = new JpegBitmapDecoder(
                        imageStreamSource, BitmapCreateOptions.PreservePixelFormat,
                        BitmapCacheOption.Default
                    );
                imgInfo.imgSource = decoder.Frames[0];
                imgInfo.filePath = fileName;
                imgInfo.resolutionX = decoder.Frames[0].PixelWidth;
                imgInfo.resolutionY = decoder.Frames[0].PixelHeight;
               
            
               
                decoder.DownloadCompleted += (s, args) =>
                {
                    imageStreamSource.Close();
                };
            }
            return imgInfo;
        }
    }
}
