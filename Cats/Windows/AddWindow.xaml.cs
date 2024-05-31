using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Cats.Core;
using Cats.Data;
using Cats.Service;
using Microsoft.Win32;

namespace Cats
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public CatType CatType { get; set; }
        public DateTime BirthDay { get; set; }
        public Cat NewCat { get; set; }
        public AddWindow()
        {
            InitializeComponent();
            IdField.Visibility = UserContext.CurrentUser.isAdmin == true ? Visibility.Visible : Visibility.Collapsed;
            GenderCb.ItemsSource = new string[2] {"Кот", "Кошка"};
            CatTypeCb.ItemsSource = DataBaseManager.GetAllCatTypes();
        }

        public AddWindow(Cat cat)
        {
            InitializeComponent();
            GenderCb.ItemsSource = new string[2] { "Кот", "Кошка" };
            CatTypeCb.ItemsSource = DataBaseManager.GetAllCatTypes();
            if (cat.Image != null)ImgHolder.Source = ByteImageConverter.ByteToImage(cat.Image);
            Image = cat.Image;
            IdTb.Text = cat.ID;
            NameTb.Text = cat.Name;
            GenderCb.Text = cat.Gender.Trim();
            CatTypeCb.SelectedItem = cat.CatType;
            BirthdayDatePicker.SelectedDate = cat.Birthday;
            IdTb.IsEnabled = false;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (BirthdayDatePicker.SelectedDate == null || CatTypeCb.SelectedItem == null ||
            //    GenderCb.Text == "" || NameTb.Text == "")
            //{
            //    MessageBox.Show("Заполните все поля!");
            //    return;
            //}
            Random rnd = new Random();
            CatTypeCb.SelectedItem = DataBaseManager.GetAllCatTypes()[rnd.Next(DataBaseManager.GetAllCatTypes().Count)];
            GenderCb.SelectedItem = ((string[]) ["Кот", "Кошка"])[rnd.Next(1)];
            DialogResult = true;
            NewCat = new Cat()
            {
                ID = IdTb.Text == "" ? Guid.NewGuid().ToString() : IdTb.Text,
                AddedBy = UserContext.CurrentUser.ID,
                Birthday = (DateTime)BirthdayDatePicker.SelectedDate,
                CatTypeID = ((CatType)CatTypeCb.SelectedItem).ID,
                Gender = GenderCb.Text,
                Image = Image,
                Name = NameTb.Text
            };
            this.Close();
        }

        private void LoadImg()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a photo";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Image = ByteImageConverter.File2Byte(op.FileName);
            }
        }

        

        private void AddImgBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadImg();
            if(Image != null) ImgHolder.Source = ByteImageConverter.ByteToImage(Image);
        }
    }
}
