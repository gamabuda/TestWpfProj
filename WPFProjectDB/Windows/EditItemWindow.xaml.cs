using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using WPFProjectDB.DataBaseConnection;

namespace TestWpfProj.Windows
{
    public partial class EditItemWindow : Window
    {
        private Languages _language;
        private byte[] _img = new byte[0];
        private Users _currentUser;

        public EditItemWindow(Languages lang, Users user)
        {
            InitializeComponent();
            _language = lang;
            _currentUser = user;
            this.DataContext = _language;

            if (_language.Image != null && _language.Image.Length > 0)
            {
                ObjectImg.Source = ByteArrayToImage(_language.Image);
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
                _img = ImageToByteArray(img);
                ObjectImg.Source = img;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_currentUser.Role_id == 1)
            {
                _language.Image = _img;
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("У вас нет прав для сохранения изменений.", "Ошибка доступа", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private byte[] ImageToByteArray(BitmapImage image)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                return stream.ToArray();
            }
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
