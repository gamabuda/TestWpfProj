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
using Cats.Core;
using Cats.Data;

namespace Cats
{
    /// <summary>
    /// Логика взаимодействия для DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public string Text { get { return TextElement.Text; } set { TextElement.Text = value; } }
        public DeleteWindow(Cat Cat)
        {
            InitializeComponent();
            Text = $"Are you sure want to delete {Cat.Name}?";
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
