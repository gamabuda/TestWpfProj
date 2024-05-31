using System;
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
using Cats.Core;

namespace Cats
{
    /// <summary>
    /// Логика взаимодействия для TypesPage.xaml
    /// </summary>
    public partial class TypesPage : Page
    {
        public TypesPage()
        {
            InitializeComponent();
            ListView.ItemsSource = DataBaseManager.GetAllCatTypes();
        }

        private void DeleteMI_OnClick(object sender, RoutedEventArgs e)
        {
            if (ListView.SelectedItem is CatType type) DataBaseManager.RemoveCatType(type);
            ListView.ItemsSource = DataBaseManager.GetAllCatTypes();
            var main = Application.Current.MainWindow as MainWindow;
            main._mainPage.LstView.Items.Refresh();
        }

        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            AddTypeWindow addWindow = new();
            addWindow.ShowDialog();
            if (addWindow.DialogResult == false) return;
            DataBaseManager.AddCatType(addWindow.NewType);
            ListView.ItemsSource = DataBaseManager.GetAllCatTypes();
            var main = Application.Current.MainWindow as MainWindow;
            main._mainPage.LstView.Items.Refresh();
        }
    }
}
