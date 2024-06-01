using MemeWpfApp.Data;
using MemeWpfApp.DbConnection;
using MemeWpfApp.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemeWpfApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomeItemPage.xaml
    /// </summary>
    public partial class HomeItemPage : Page
    {
        private List<HomeItem> homeItems;
        public HomeItemPage()
        {
            InitializeComponent();

            homeItems = DataBaseManager.GetHomeItems();
            HomeItemLv.DataContext = homeItems;
            HomeItemLv.ItemsSource = homeItems;
        }

        private void AddNewBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddHomeItemWindow().ShowDialog();
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            var item = HomeItemLv.SelectedItem as HomeItem;

            if (item == null)
                return;

            new EditHomeItemWindow(item).ShowDialog();
        }

        private void UpdateMI_Click(object sender, RoutedEventArgs e)
        {
            homeItems = DataBaseManager.GetHomeItems();
            HomeItemLv.ItemsSource = homeItems;
            HomeItemLv.Items.Refresh();
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            var item = HomeItemLv.SelectedItem as HomeItem;

            if(item == null)
                return;
            
            DataBaseManager.RemoveHomeItem(item);

            HomeItemLv.Items.Refresh();
        }
    }
}
