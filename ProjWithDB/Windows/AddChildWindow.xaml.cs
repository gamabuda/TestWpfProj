using Microsoft.Win32;
using ProjWithDB.Data;
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

namespace ProjWithDB.Windows
{
    public partial class AddChildWindow : Window
    {

        private User _user;
        private Child _child;
        private byte[] _img = new byte[0];

        public AddChildWindow()
        {
            InitializeComponent();
            _child = new Child();
        }

        private void DeletePhoto_Click(object sender, RoutedEventArgs e)
        {
            _img = null;
            ObjectImg.Source = null;
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
                _img = File2Byte(op.FileName);
                ObjectImg.Source = img;
                LoadImgBtn.Background = Brushes.Lavender;
                LoadImgBtn.BorderBrush = Brushes.Transparent;
            }
        }

        public Byte[] File2Byte(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                return File.ReadAllBytes(filePath);

            return null;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Surname_TB.Text) || String.IsNullOrEmpty(Name_TB.Text) || String.IsNullOrEmpty(Patronymic_TB.Text) || String.IsNullOrEmpty(Gender_TB.Text) || String.IsNullOrEmpty(Age_TB.Text) || String.IsNullOrEmpty(RoomNumber_TB.Text) || String.IsNullOrEmpty(MoveInDate_TB.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                _child.Surname = Surname_TB.Text;
                _child.Name = Name_TB.Text;
                _child.Patronymic = Patronymic_TB.Text;
                if (Gender_TB.Text.ToUpper() != "М" && Gender_TB.Text.ToUpper() != "Ж")
                {
                    MessageBox.Show("Некорректный пол (М / Ж)!", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                } 
                _child.Gender = Gender_TB.Text.ToUpper();
                _child.Age = Convert.ToInt32(Age_TB.Text);
                _child.RoomNumber = Convert.ToInt32(RoomNumber_TB.Text);
                _child.Photo = _img;
                _child.MoveInDate = DateTime.Parse(MoveInDate_TB.Text);

                DBManager.AddChild(_child);
                DBManager.UpdateDatabase();
                MessageBox.Show("Ребенок заселен!", "Заселение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            } catch
            {
                MessageBox.Show("Некорректные данные!", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
