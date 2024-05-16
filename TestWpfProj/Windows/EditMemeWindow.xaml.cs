using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для EditMemeWindow.xaml
    /// </summary>
    public partial class EditMemeWindow : Window
    {
        private Meme _editMeme;
        public EditMemeWindow(Meme meme)
        {
            InitializeComponent();

            this.DataContext = _editMeme = meme;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        { 
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
