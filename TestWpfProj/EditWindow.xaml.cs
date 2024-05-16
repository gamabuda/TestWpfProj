using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TestWpfProj
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public string Name { get { return NameField.Text; } set { NameField.Text = value; } }
        public Birthday Birthday 
        { 
            get 
            {
                return _birthday;
            } 
            set 
            {
                _birthday = value;
                BirthdayField.Text = value.BirthdayString;
            } 
        }
        Birthday _birthday;
        public CatType CatType { get { return (CatType)CatTypeField.SelectedItem; } set { CatTypeField.SelectedItem = value; } }

        public EditWindow(string Name, Birthday Birthday, CatType Cattype)
        {
            InitializeComponent();
            this.Name = Name;
            this.Birthday = Birthday;
            CatType = Cattype;
            CatTypeField.ItemsSource = Data.DataContext.CatTypes;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            Birthday.AddDay();
            BirthdayField.Text = Birthday.BirthdayString;
        }

        private void MinusButton_Click(Object sender, RoutedEventArgs e)
        {
            Birthday.RemoveDay();
            BirthdayField.Text = Birthday.BirthdayString;
        }
    }
}
