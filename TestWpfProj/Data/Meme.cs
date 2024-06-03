using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public class Genre
    {
        public string Name { get; set; }

        public Genre(string name)
        {
            Name = name;
        }
    }

    public class Media
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }

        public Media(string title, Genre genre)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Genre = genre;
        }
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
