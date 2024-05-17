using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using TestWpfProj.Data;
using TestWpfProj.Windows;

namespace TestWpfProj
{
    public partial class MainWindow : Window
    {
        private List<Language> _languages;
        private List<LanguageType> _languageTypes;
        private User _authorizedUser;
        public MainWindow(User user)
        {
            InitializeComponent();

            _authorizedUser = user;
            UserTB.Text = _authorizedUser.Name;

            _languages = Data.DataContext.Languages;
            _languageTypes = Data.DataContext.LanguageTypes;

            LstView.ItemsSource = _languages;
            FilterCB.ItemsSource = _languageTypes;
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Language selectedLang = (Language)LstView.SelectedItem;

            if (selectedLang == null)
            {
                MessageBox.Show("Пожалуйста, выберите элемент для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить '{selectedLang.Title}'?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _languages.Remove(selectedLang);
                UpdateListView();
            }
        }

        private void ViewMI_Click(object sender, RoutedEventArgs e)
        {
            Language selectedLang = (Language)LstView.SelectedItem;
            new ViewItemWindow(selectedLang).ShowDialog();
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            Language selectedLang = (Language)LstView.SelectedItem;
            if (new EditItemWindow(selectedLang).ShowDialog() == true)
            {
                UpdateListView();
            }
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
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
                tempLst = tempLst.Where(x => x.LanguageType.Id == type.Id);
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
                var selectedLanguages = LstView.ItemsSource as List<Language>;
                ExportToCSV(selectedLanguages, saveFileDialog.FileName);
                MessageBox.Show("Экспорт завершен успешно!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ExportToCSV(List<Language> languages, string filePath)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Id,Title,Type,Price");

            foreach (var lang in languages)
            {
                csv.AppendLine($"{lang.Id},{lang.Title},{lang.LanguageType.Title},{lang.Price}");
            }

            File.WriteAllText(filePath, csv.ToString());
        }
    }
}
