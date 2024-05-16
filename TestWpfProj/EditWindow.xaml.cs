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
        public string Title { get { return TitleField.Text; } set { TitleField.Text = value; } }
        public decimal Price { get { return Convert.ToDecimal(PriceField.Text); } set { PriceField.Text = Convert.ToString(value); } }
        public MemeType MemeType { get { return (MemeType)MemeTypeField.SelectedItem; } set { MemeTypeField.SelectedItem = value; } }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public EditWindow(string title, decimal price, MemeType memetype)
        {
            InitializeComponent();
            Title = title;
            Price = price;
            MemeType = memetype;
            MemeTypeField.ItemsSource = Data.DataContext.MemeTypes;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
