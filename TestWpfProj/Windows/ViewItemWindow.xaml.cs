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
using TestWpfProj.Data;

namespace TestWpfProj.Windows
{
    /// <summary>
    /// Логика взаимодействия для ViewItemWindow.xaml
    /// </summary>
    public partial class ViewItemWindow : Window
    {
        private Film _viewFilm;
        public ViewItemWindow(Film film)
        {
            InitializeComponent();

            _viewFilm = film;
            this.DataContext = _viewFilm;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
