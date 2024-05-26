using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Cats.Data
{
    public static class ByteImageConverter
    {
        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();
            ImageSource imgSrc = biImg as ImageSource;
            return imgSrc;
        }

        public static Byte[] File2Byte(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                return File.ReadAllBytes(filePath);
            }
            return null;
        }
    }
}
