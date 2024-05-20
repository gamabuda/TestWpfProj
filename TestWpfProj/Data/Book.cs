using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public class Book
    {
        public Book(string title, BookGenre genre, decimal price, string writer)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            BookGenre = genre;
            Price = price;
            Writer = writer;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public BookGenre? BookGenre { get; set; }

        public decimal Price { get; set; } = 0;
        public string Writer { get; set; }
    }
}
