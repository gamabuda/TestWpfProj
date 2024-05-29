using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using WPFProjectDB.Data;
using WPFProjectDB.DataBaseConnection;

namespace WPFProjectDB
{
    public partial class ProfileWindow : Window
    {
        private Users _user;
        private byte[] _img;

        public ProfileWindow(Users user)
        {
            InitializeComponent();
            _user = user;
            DataContext = _user;

            if (_user.UserImage != null && _user.UserImage.Length > 0)
            {
                ObjectImg.Source = ByteArrayToImage(_user.UserImage);
                _img = _user.UserImage;
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SetImgBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Выберите фотографию";
            op.Filter = "Все поддерживаемые форматы|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "PNG (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                var img = new BitmapImage(new Uri(op.FileName));
                _img = ImageToByteArray(img);
                ObjectImg.Source = img;
                _user.UserImage = _img;

                // Сохранение изменений в базу данных
                if (DataBaseManager.UpdateUser(_user))
                {
                    MessageBox.Show("Фотография успешно обновлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при обновлении фотографии.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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
