using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TestWpfProj.Windows;
using WPFProjectDB.Data;
using WPFProjectDB.DataBaseConnection;
using System.IO;

namespace WPFProjectDB
{
    public partial class MainWindow : Window
    {
        Users CurrentUser;
        private List<Languages> _languages;
        private List<LanguageType> _languageTypes;

        public MainWindow(Users user)
        {
            InitializeComponent();

            CurrentUser = user;
            UserTB.Text = CurrentUser.Username;

            _languageTypes = DataBaseManager.GetLanguageTypes();
            _languages = DataBaseManager.GetLanguages();

            LstView.ItemsSource = _languages;
            FilterCB.ItemsSource = _languageTypes;
        }

        private void UserTB_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow(CurrentUser);
            profileWindow.ShowDialog();
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Languages selectedLang = (Languages)LstView.SelectedItem;

            if (selectedLang == null)
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить '{selectedLang.Title}'?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                if (DataBaseManager.RemoveLanguage(selectedLang))
                {
                    _languages.Remove(selectedLang);
                    UpdateListView();
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении элемента.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ViewMI_Click(object sender, RoutedEventArgs e)
        {
            Languages selectedLang = (Languages)LstView.SelectedItem;
            new ViewItemWindow(selectedLang).ShowDialog();
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            Languages selectedLang = (Languages)LstView.SelectedItem;
            if (new EditItemWindow(selectedLang).ShowDialog() == true)
            {
                UpdateListView();
            }
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            _languages = DataBaseManager.GetLanguages();
            UpdateListView();
        }

        private void SerchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateListView();
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListView();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListView();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FilterCB.SelectedItem = null;
            UpdateListView();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SortCB.SelectedItem = null;
            UpdateListView();
        }

        private void UpdateListView()
        {
            var tempLst = _languages.AsEnumerable();

            if (!string.IsNullOrEmpty(SerchTB.Text))
            {
                tempLst = tempLst.Where(x => x.Title.Contains(SerchTB.Text));
            }

            var type = (LanguageType)FilterCB.SelectedItem;
            if (type != null)
            {
                tempLst = tempLst.Where(x => x.LanguageType_Id == type.LanguageType_Id);
            }

            if (SortCB.SelectedItem != null)
            {
                var selectedSort = (ComboBoxItem)SortCB.SelectedItem;
                string sortContent = selectedSort.Content.ToString();

                switch (sortContent)
                {
                    case "От А до Я":
                        tempLst = tempLst.OrderBy(x => x.Title);
                        break;
                    case "От Я до А":
                        tempLst = tempLst.OrderByDescending(x => x.Title);
                        break;
                    case "По возрастанию цены":
                        tempLst = tempLst.OrderBy(x => x.Price);
                        break;
                    case "По убыванию цены":
                        tempLst = tempLst.OrderByDescending(x => x.Price);
                        break;
                }
            }

            LstView.ItemsSource = tempLst.ToList();
            LstView.Items.Refresh();
        }

        private void ExportToCSV_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FileName = "languages.csv";

            if (saveFileDialog.ShowDialog() == true)
            {
                var selectedLanguages = LstView.ItemsSource as List<Languages>;
                ExportToCSV(selectedLanguages, saveFileDialog.FileName);
                MessageBox.Show("Экспорт завершен успешно!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ExportToCSV(List<Languages> languages, string filePath)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Language_Id,Title,LanguageType,Price");

            foreach (var lang in languages)
            {
                csv.AppendLine($"{lang.Language_Id},{lang.Title},{lang.LanguageType.Title},{lang.Price}");
            }

            File.WriteAllText(filePath, csv.ToString());
        }
    }
}
