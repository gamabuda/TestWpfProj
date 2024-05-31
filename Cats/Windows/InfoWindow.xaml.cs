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
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public Cat Cat { get; set; }
        public InfoWindow(Cat cat)
        {
            InitializeComponent();
            NameTb.Text = cat.Name;
            IdTb.Text = cat.ID;
            GenderTb.Text = cat.Gender;
            BirthdayTb.Text = cat.Birthday.ToShortDateString();
            if (cat.Image != null) ImageB.Source = ByteImageConverter.ByteToImage(cat.Image);
        }
    }
}
