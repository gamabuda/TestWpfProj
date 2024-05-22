using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using WpfProj.Framework.Data;
using WpfProj.Framework.DbConnection;

namespace WpfProj.Framework
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Meme> _memes = new List<Meme>();
        public MainWindow()
        {
            InitializeComponent();

            _memes = DataBaseManager.GetMemes();
            MemeLv.DataContext = this;
            MemeLv.ItemsSource = _memes;

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MemeLv.SelectedItem == null)
            {
                MessageBox.Show("Choose item!");
                return;
            }

            var memes = MemeLv.SelectedItem as Meme;
            LoadImg(memes);
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadImg(Meme memes)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a photo";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                memes.Photo = File2Byte(op.FileName);
                DataBaseManager.SaveChanges();
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

        public Byte[] Image2Byte(BitmapImage imageSource)
        {
            Stream stream = imageSource.StreamSource;
            Byte[] buffer = null;
            if (stream != null && stream.Length > 0)
            {
                using (BinaryReader br = new BinaryReader(stream))
                {
                    buffer = br.ReadBytes((Int32)stream.Length);
                }
            }

            return buffer;
        }
    }
}
