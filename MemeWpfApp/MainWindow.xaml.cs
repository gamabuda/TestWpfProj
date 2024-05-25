using MemeWpfApp.Data;
using MemeWpfApp.DbConnection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace MemeWpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Meme> _memes;
        public MainWindow()
        {
            InitializeComponent();

            _memes = DataBaseManager.GetMemes();

            MemeLv.DataContext = this;  
            MemeLv.ItemsSource = _memes;
        }

        private void ChangeImageMI_Click(object sender, RoutedEventArgs e)
        {
            var selectMeme = MemeLv.SelectedItem as Meme;
            if (selectMeme != null)
                LoadImg(selectMeme);
            else
                MessageBox.Show("Somthing wrong :(");

            
            MemeLv.Items.Refresh();
        }

        private void LoadImg(Meme meme)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a photo";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                meme.Image = File2Byte(op.FileName);
                DataBaseManager.UpdateDatabase();
            }
        }

        public Byte[] File2Byte(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                return File.ReadAllBytes(filePath);
            }
            return null;
        }

        private void CopyMI_Click(object sender, RoutedEventArgs e)
        {
            var selectMeme = MemeLv.SelectedItem as Meme;
            if (selectMeme != null)
            {
                var temp = selectMeme;
                temp.Id = 0;
                DataBaseManager.AddMeme(temp);
                DataBaseManager.UpdateDatabase();
            }
            else
                MessageBox.Show("Somthing wrong :(");
        }

        private void UpdateMI_Click(object sender, RoutedEventArgs e)
        {
            _memes = DataBaseManager.GetMemes();
            MemeLv.ItemsSource = _memes;
            MemeLv.Items.Refresh();
        }
    }
}
