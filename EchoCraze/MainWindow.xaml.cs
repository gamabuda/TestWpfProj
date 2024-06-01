using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EchoCraze.Base;
using EchoCraze.MainPages;

namespace EchoCraze
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private List<Melody> _melodies;
        private List<SortType> _sortTypes;
        private List<Genre> _genres;


        public MainWindow(User user)
        {
            InitializeComponent();
            

            _melodies = Base.Basedb.GetMelodyes();
            _sortTypes = Base.Basedb.GetSortTypes();
            _genres = Base.Basedb.GetGenres();


            MelodyLv.DataContext = this;
            MelodyLv.ItemsSource = _melodies;

            SortCB.DisplayMemberPath = "Title";
            SortCB.ItemsSource = _sortTypes;

            FilterCB.DisplayMemberPath = "Title";
            FilterCB.ItemsSource = _genres;


            Filter.DisplayMemberPath = "Title";
            Filter.ItemsSource = _genres;
        }


       
        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Melody selectedMeme = (Melody)MelodyLv.SelectedItem;
            _melodies.Remove(selectedMeme);

            MelodyLv.ItemsSource = _melodies;
            MelodyLv.Items.Refresh();
        }

        private void ViewMI_Click(object sender, RoutedEventArgs e)
        {
            //    Melody selectedMeme = (Melody)MelodyLv.SelectedItem;
            //new ViewWindow(selectedMeme).ShowDialog();
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            MelodyLv.ItemsSource = _melodies;
            MelodyLv.Items.Refresh();
        }
        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            //Meme selectedMeme = (Meme)MemeLV.SelectedItem;
            //new EditWindow(selectedMeme).ShowDialog();
        }




        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            var selectedGenre = (Genre)Filter.SelectedItem;
            var melody = new Melody()
            {
                Id_Melody = random.Next(1, 100),
                Title = MelodyTitleTb.Text,
                Author = AuthorTb.Text,
                Album = AlbumTb.Text,

                Genre = selectedGenre
            };

            if (Basedb.AddMelody(melody))
            {
                _melodies.Add(melody);
                MelodyLv.ItemsSource = _melodies.ToList();
            }
            else
            {
                MessageBox.Show("Failed to add melody to the database.");
            }


        }





        private void FilterCB_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var filter = _melodies;

            var genre = (Genre)FilterCB.SelectedItem;

            if (genre == null)
                return;

            filter = filter.Where(x => x.Genre.Id_Genre == genre.Id_Genre).ToList();
            MelodyLv.ItemsSource = filter;
            MelodyLv.Items.Refresh();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tempLst = _melodies;

            if (!String.IsNullOrEmpty(SearchTB.Text))
            {
                tempLst = _melodies.Where(x => x.Title.Contains(SearchTB.Text)).ToList();
            }

            MelodyLv.ItemsSource = tempLst;
            MelodyLv.Items.Refresh();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = SortCB.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < _sortTypes.Count)
            {
                var sortedMelodies = _melodies.ToList();

                switch (selectedIndex)
                {
                    case 0:

                        break;
                    case 1:
                        sortedMelodies = sortedMelodies.OrderBy(melody => melody.Title).ToList();
                        break;
                    case 2:
                        sortedMelodies = sortedMelodies.OrderByDescending(melody => melody.Title).ToList();
                        break;
                    case 3:
                        sortedMelodies = sortedMelodies.OrderBy(melody => melody.Most_listened_to).ToList();
                        break;
                    case 4:
                        sortedMelodies = sortedMelodies.OrderByDescending(melody => melody.Most_listened_to).ToList();
                        break;
                    default:
                        break;
                }

                MelodyLv.ItemsSource = sortedMelodies;
                MelodyLv.Items.Refresh();
            }
        } 
    }
}
