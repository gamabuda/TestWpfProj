using MemeWpfApp.Data;
using MemeWpfApp.DbConnection;
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

namespace MemeWpfApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditHomeItemWindow.xaml
    /// </summary>
    public partial class EditHomeItemWindow : Window
    {
        private HomeItem homeItem = new HomeItem();

        public EditHomeItemWindow(HomeItem Item)
        {
            InitializeComponent();

            this.homeItem = Item;
            DataContext = homeItem;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddNewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!DataBaseManager.AddHomeItem(homeItem))
            {
                MessageBox.Show("Somthing wrong! Try again later.");
                return;
            }

            this.Close();
        }
    }
}
