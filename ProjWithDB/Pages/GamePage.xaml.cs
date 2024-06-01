using ProjWithDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ProjWithDB.Windows;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjWithDB.Data;

namespace ProjWithDB.Pages
{
    public partial class GamePage : Page
    {
        private readonly List<Child> children;
        private Child correctChild;
        private readonly Random random;
        private int score;

        public GamePage()
        {
            InitializeComponent();
            this.children = DBManager.GetChild();
            random = new Random();
        }

       
        public void StartGame()
        {
            GameGrid.Children.Clear();
            score = 0;

            // Выбираем четыре случайных детей
            var selectedChildren = children.OrderBy(x => random.Next()).Take(4).ToList();
            correctChild = selectedChildren[random.Next(4)];

            // Добавляем фотографии детей и кнопки ответов
            for (int i = 0; i < 4; i++)
            {
                var child = selectedChildren[i];
                var image = new Image
                {
                    Source = BitmapSource.Create(
                        child.Photo.Length, 1, 96, 96, PixelFormats.Bgr24, null, child.Photo, 96),
                    Width = 512,
                    Height = 512,
                    Margin = new Thickness(10)
                };
                GameGrid.Children.Add(image);

                var button = new Button
                {
                    Content = child.Name,
                    Tag = child,
                    Margin = new Thickness(10)
                };
                button.Click += OnAnswerButtonClick;
                GameGrid.Children.Add(button);
            }
        }

        private void OnAnswerButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var selectedChild = (Child)button.Tag;
            // Проверяем, является ли выбранный ребенок правильным
            if (selectedChild == correctChild)
            {
                MessageBox.Show("Верно!", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                score++;
            }
            else
            {
                MessageBox.Show("Неверно!", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Обновляем счет
            ScoreTextBlock.Text = $"Счет: {score}";
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }
    }
}