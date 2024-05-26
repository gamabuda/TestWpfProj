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
using Microsoft.Win32;

namespace Cats
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddTypeWindow : Window
    {
        public CatType NewType { get; set; }
        public AddTypeWindow()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            NewType = new CatType()
            {
                ID = Guid.NewGuid().ToString(),
                Title = this.TitleTb.Text
            };
            this.Close();
        }
    }
}
