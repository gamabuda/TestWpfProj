using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using ProjWithDB.Data;
using ProjWithDB.Data.Users;

namespace ProjWithDB.Windows
{
    public partial class EditInfoWindow : Window
    {
        private User _user;
        private byte[] _img = new byte[0];
        private Child _selectedChild;
        public EditInfoWindow(Child selectedPerson, User user)
        {
            InitializeComponent();
            _user = user;
            _selectedChild = selectedPerson;
            this.DataContext = _selectedChild;
            MoveInDate_TB.Text = _selectedChild.MoveInDate.ToString();

            if (_user.Guest.Count > 0)
            {
                LoadImgBtn.IsEnabled = false;
                Info_SP.IsEnabled = false;
                ID_SP.Visibility = Visibility.Hidden;
                SaveBtn.Visibility = Visibility.Hidden;
                CloseBtn.Visibility = Visibility.Hidden;
                EditBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
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
                _img = Image2Byte(img);
                ObjectImg.Source = img;
                
                LoadImgBtn.Background = Brushes.Lavender;
                LoadImgBtn.BorderBrush = Brushes.Transparent;
            }
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

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Surname_TB.Text) || String.IsNullOrEmpty(Name_TB.Text) || String.IsNullOrEmpty(Patronymic_TB.Text) || String.IsNullOrEmpty(Gender_TB.Text) || String.IsNullOrEmpty(Age_TB.Text) || String.IsNullOrEmpty(RoomNumber_TB.Text) || String.IsNullOrEmpty(MoveInDate_TB.Text))
                return;

            _selectedChild.Surname = Surname_TB.Text;
            _selectedChild.Name = Name_TB.Text;  
            _selectedChild.Patronymic = Patronymic_TB.Text;
            _selectedChild.Gender = Gender_TB.Text;
            _selectedChild.Age = Convert.ToInt32(Age_TB.Text);
            _selectedChild.RoomNumber = Convert.ToInt32(RoomNumber_TB.Text);
            try
            {
                _selectedChild.MoveInDate = DateTime.Parse(MoveInDate_TB.Text);
            } catch 
            {
                MoveInDate_TB.Text = _selectedChild.MoveInDate.ToString();
                return;
            }
            

            LoadImgBtn.IsEnabled = false;
            SaveBtn.IsEnabled = false;
            Info_SP.IsEnabled = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadImgBtn.IsEnabled = true;
            SaveBtn.IsEnabled = true;
            Info_SP.IsEnabled = true;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить этого человека?",
                    "Удаление информации",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ChildrenHomeEntities.GetContext().Child.Remove(_selectedChild);
                this.Close();
            }
        }
    }
}
