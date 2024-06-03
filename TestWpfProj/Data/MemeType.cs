using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public class Genre
    {
        public Genre(string title)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
        }

        public string Id { get; set; }
        public string Title { get; set; }
    }

    public class Media
    {
        public Media(string title, Genre genre)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Genre = genre;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
    }

    public class Movie : Media
    {
        public Movie(string title, Genre genre) : base(title, genre)
        {
        }
    }

    public class Series : Media
    {
        public Series(string title, Genre genre) : base(title, genre)
        {
        }
    }
}