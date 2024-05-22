using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using WpfProj.Framework.DbConnection;

namespace WpfProj.Framework
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBaseEntities dataBase = new DataBaseEntities();
        public MainWindow()
        {
            InitializeComponent();
            
            MemeLv.DataContext = this;
            MemeLv.ItemsSource = dataBase.Meme.ToList();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var meme = new Meme()
                {
                    ID = Guid.NewGuid().ToString(),
                    Title = MemeTitleTb.Text,
                    Price = (decimal)0,
                    MemeTypeID = dataBase.MemeType.First().ID
                };

                dataBase.Meme.Add(meme);
                dataBase.SaveChanges();

                MemeLv.DataContext = this;
                MemeLv.ItemsSource = dataBase.Meme.ToList();
            } 
            catch(DbEntityValidationException ex) 
            {
                var sb = new StringBuilder();

                foreach (var f in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} fail validation\n", f.Entry.Entity.GetType());
                    foreach(var err in f.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", err.PropertyName, err.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Fail: " + sb.ToString(), ex);
            }
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedMeme = MemeLv.SelectedItem as Meme;
                dataBase.Meme.Remove(selectedMeme);
                dataBase.SaveChanges();

                MemeLv.DataContext = this;
                MemeLv.ItemsSource = dataBase.Meme.ToList();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var f in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} fail validation\n", f.Entry.Entity.GetType());
                    foreach (var err in f.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", err.PropertyName, err.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Fail: " + sb.ToString(), ex);
            }
        }
    }
}
