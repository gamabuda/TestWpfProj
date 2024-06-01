using System.Collections.ObjectModel;
using System.Windows;
using WPFProjectDB.Data;
using WPFProjectDB.DataBaseConnection;

namespace WPFProjectDB.Windows
{
    /// <summary>
    /// Interaction logic for LangTypeWindow.xaml
    /// </summary>
    public partial class LangTypeWindow : Window
    {
        public ObservableCollection<LanguageType> LanguageTypes { get; set; }
        public LanguageType SelectedLanguageType { get; set; }

        public LangTypeWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadData();
        }

        private void LoadData()
        {
            LanguageTypes = new ObservableCollection<LanguageType>(DataBaseManager.GetLanguageTypes());
            LanguageTypeListView.ItemsSource = LanguageTypes;
        }

        private void AddLanguageType_Click(object sender, RoutedEventArgs e)
        {
            var newLanguageType = new LanguageType { Title = "New Language" };
            if (DataBaseManager.AddLanguageType(newLanguageType))
            {
                LanguageTypes.Add(newLanguageType);
            }
        }

        private void UpdateLanguageType_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedLanguageType != null)
            {
                DataBaseManager.UpdateLanguageType(SelectedLanguageType);
                LanguageTypeListView.Items.Refresh();
            }
        }

        private void RemoveLanguageType_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedLanguageType != null)
            {
                if (DataBaseManager.RemoveLanguageType(SelectedLanguageType))
                {
                    LanguageTypes.Remove(SelectedLanguageType);
                }
            }
        }
    }
}
