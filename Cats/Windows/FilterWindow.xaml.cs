#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Cats;
using Cats.Core;
using Cats.Data;

namespace Cats
{
    /// <summary>
    /// Логика взаимодействия для FilterWindow.xaml
    /// </summary>
    public partial class FilterWindow : Window
    {
        public List<CatType>? CatTypes { get; set; }
        public Sort? Sort { get; set; }
        public bool Reversed { get; set; }
        public FilterWindow(List<CatType>? catTypes, Sort? sort, bool? isChecked = false)
        {
            InitializeComponent();
            this.CatTypes = catTypes ?? [];
            Sort = sort;
            isReversed.IsChecked = isChecked;
            Reversed = isChecked.Value;
            FilterCB.ItemsSource = DataBaseManager.GetAllCatTypes();
            SortCB.ItemsSource = SortsList.SortList;
            SortCB.SelectedItem = sort;
            RefreshFilters();
        }

        private void FilterClear(object sender, RoutedEventArgs e)
        {
            CatTypes.Clear();
            FiltersStackPanel.Children.Clear();
        }

        private void SortClear(object sender, RoutedEventArgs e)
        {
            SortCB.SelectedItem = null;
            Sort = null;
        }

        private void RefreshFilters()
        {
            FiltersStackPanel.Children.Clear();
            if (CatTypes != null)
                foreach (var type in CatTypes)
                {
                    var fb = new FilterBrick(type);

                    void RoutedEventHandler(object o, RoutedEventArgs e) 
                    {
                        CatTypes.Remove(fb.CatType);
                        FiltersStackPanel.Children.Remove(fb.FilterElement);
                    }

                fb.MinusAction += new RoutedEventHandler(RoutedEventHandler);
                FiltersStackPanel.Children.Add(fb.FilterElement);
                }
        }
        
        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FilterCB_DropDownClosed(object sender, EventArgs e)
        {
            if (FilterCB.SelectedItem != null && !CatTypes.Contains(FilterCB.SelectedItem))
            {
                CatTypes.Add(FilterCB.SelectedItem as CatType);
                RefreshFilters();
            }
            FilterCB.SelectedItem = null;
        }

        private void SortCB_DropDownClosed(object sender, EventArgs e)
        {
            Sort = SortCB.SelectedItem as Sort;
        }

        private void isReversed_Checked(object sender, RoutedEventArgs e)
        {
            Reversed = true;
        }

        private void isReversed_Unchecked(object sender, RoutedEventArgs e)
        {
            Reversed = false;
        }
    }

    public class FilterBrick
    {
        public CatType CatType { get; set; }
        public Grid FilterElement { get; set; }
        private Label NameLabel { get; set; }
        private Button MinusBtn { get; set; }

        public RoutedEventHandler MinusAction
        {
            get => _minusEventHandler;
            set
            { 
                _minusEventHandler = value;
                MinusBtn.Click += value;
            }
        }

        private RoutedEventHandler _minusEventHandler;
        public FilterBrick(CatType catType)
        {
            CatType = catType;
            InitComponent();
        }

        private void InitGrid()
        {
            FilterElement = new Grid() { Width = 260};
            FilterElement.ColumnDefinitions.Add(new ColumnDefinition());
            FilterElement.ColumnDefinitions.Add(new ColumnDefinition());
            FilterElement.MaxHeight = 250;
        }

        private void InitContent()
        {
            NameLabel = new Label()
            {
                Content = CatType.Title, 
                HorizontalAlignment = HorizontalAlignment.Left
            };
            MinusBtn = new Button()
            {
                Content = "—", 
                HorizontalAlignment = HorizontalAlignment.Right, 
                Margin = new Thickness(0, 0, 15, 0),
                Padding = new Thickness(3, 0, 3, 0)
            };
            FilterElement.Children.Add(NameLabel);
            FilterElement.Children.Add(MinusBtn);
            Grid.SetColumn(NameLabel, 0);
            Grid.SetColumn(MinusBtn, 1);
        }

        private void InitComponent()
        {
            InitGrid();
            InitContent();
        }
    }
}
