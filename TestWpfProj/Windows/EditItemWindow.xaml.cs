using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestWpfProj.Data;
using System.IO;
using Microsoft.Win32;
using static TestWpfProj.MainWindow;

namespace TestWpfProj.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditItemWindow.xaml
    /// </summary>
    public partial class EditItemWindow : Window
    {
        private Meme _meme;
        private byte[] _img;

        public EditItemWindow(Meme meme)
        {
            InitializeComponent();
            _meme = meme;
            this.DataContext = _meme;

            if (_meme.Image != null)
            {
                ObjectImg.Source = ByteToImage(_meme.Image);
            }
        }
        private BitmapImage ByteToImage(byte[] imageData)
        {
            using (var ms = new MemoryStream(imageData))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        private void LoadImgBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a photo";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                var img = new BitmapImage(new Uri(op.FileName));
                // 2 byte[]
                _img = Image2Byte(img);
                // path
                ObjectImg.Source = img;
            }
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_img != null)
            {
                _meme.Image = _img;
            }

            this.DialogResult = true;
            this.Close();
        }

        public Byte[] Image2Byte(BitmapImage imageSource)
        {
            Stream stream = imageSource.StreamSource;
            Byte[] buffer = null;
            if (stream != null && stream.Length > 0)
            {
                using (BinaryReader br = new BinaryReader(stream))
                {
                    buffer = br.ReadBytes((Int32)stream.Length);
                }
            }

            return buffer;
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
   
