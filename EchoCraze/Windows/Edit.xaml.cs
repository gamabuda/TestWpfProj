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

namespace EchoCraze.Windows
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private List<Melody> _melodies;
        public Edit(Melody melody)
        {
            InitializeComponent();
            _melodies = Base.Basedb.GetMelodyes();
            
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

             var melody = Base.Basedb.GetMelodyes().FirstOrDefault(x => x.Title == TitleTextBox.Text && x.Genre.Title == TypeTextBox.Text);

            if (melody != null)
            {
               
                melody.Title = TitleTextBox.Text;
                melody.Genre.Title = TypeTextBox.Text; 
                Base.Basedb.UpdateDatabase();


               
                // Database.SaveMelody(melody);

                MessageBox.Show("Changes saved successfully.");
            }
            else
            {
                MessageBox.Show("No melody selected.");
            }
        }
    }
}
