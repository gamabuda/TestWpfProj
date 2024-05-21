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
    public partial class ViewItemWindow1 : Window
    {
        private RetroGame _game;

        public ViewItemWindow1(RetroGame game)
        {
            InitializeComponent();
            _game = game;

            ObjectTitle.Text = _game.Title;
            TitleTB.Text = _game.Title;
            GameTypeTB.Text = _game.GameType.Title;
            PriceTB.Text = _game.Price.ToString();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}