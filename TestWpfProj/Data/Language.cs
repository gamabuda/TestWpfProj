using System;
using System.ComponentModel;

namespace TestWpfProj.Data
{
    public class Language : INotifyPropertyChanged
    {
        public Language(string title)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
        }

        public Language(string title, LanguageType type)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            LanguageType = type;
        }

        public Language(string title, LanguageType type, decimal price)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            LanguageType = type;
            Price = price;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public LanguageType? LanguageType { get; set; }
        public decimal Price { get; set; } = 0;


        private byte[] _imageData;
        public byte[] ImageData
        {
            get { return _imageData; }
            set
            {
                _imageData = value;
                OnPropertyChanged(nameof(ImageData));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
