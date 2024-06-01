using EchoCraze.Base;
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

namespace EchoCraze.MainPages
{
    /// <summary>
    /// Логика взаимодействия для GenrePage.xaml
    /// </summary>
    public partial class GenrePage : Window
    {
        private List<Genre> _genres;
        public GenrePage()
        {
            InitializeComponent();
            _genres = Base.Basedb.GetGenres();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
           
                Random random = new Random();

                
                var Genre = new Genre()
                {
                    Id_Genre = random.Next(1, 100),
                    Title = MelodyTitleTb.Text,   
                };

                if (Basedb.AddGenre(Genre))
                {
                     _genres.Add(Genre);
                     GenreLv.ItemsSource = _genres.ToList();
                }
                else
                {
                    MessageBox.Show("Failed to add melody to the database.");
                }
           
        }
    }
}
