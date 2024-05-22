using System;
using System.Windows;
using Cats.Data;

namespace Cats
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public string Name { get { return NameField.Text; } set { NameField.Text = value; } }
        public DateTime Birthday 
        { 
            get 
            {
                return _birthday;
            } 
            set 
            {
                _birthday = value;
                BirthdayField.Text = value.ToShortDateString();
            } 
        }
        private DateTime _birthday;
        public CatType CatType { get { return (CatType)CatTypeField.SelectedItem; } set { CatTypeField.SelectedItem = value; } }

        public EditWindow(string Name, DateTime Birthday, CatType Cattype)
        {
            InitializeComponent();
            this.Name = Name;
            this.Birthday = Birthday;
            CatType = Cattype;
            CatTypeField.ItemsSource = DataBaseManager.GetAllCatTypes();
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
            Birthday.AddDays(1);
            BirthdayField.Text = Birthday.ToShortDateString();
        }

        private void MinusButton_Click(Object sender, RoutedEventArgs e)
        {
            Birthday.AddDays(-1);
            BirthdayField.Text = Birthday.ToShortDateString();
        }
    }
}
