using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using WPFProjectDB.DataBaseConnection;

namespace TestWpfProj.Windows
{
    public partial class ViewItemWindow : Window
    {
        private Languages _viewLang;

        public ViewItemWindow(Languages lang)
        {
            InitializeComponent();
            _viewLang = lang;
            this.DataContext = _viewLang;

            if (_viewLang.Image != null && _viewLang.Image.Length > 0)
            {
                ObjectImg.Source = ByteArrayToImage(_viewLang.Image);
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private BitmapImage ByteArrayToImage(byte[] byteArray)
        {
            using (var stream = new MemoryStream(byteArray))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                return image;
            }
        }
    }
}
