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
        public string Title { get; set; }
        public Genre Genre { get; set; }

        public Media(string title, Genre genre)
        {
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

    public static class DataContext
    {
        public static List<Genre> Genres = new List<Genre>()
        {
            new Genre("Action"),
            new Genre("Comedy"),
            new Genre("Drama")
        };

        public static List<Movie> Movies = new List<Movie>()
        {
            new Movie("The Matrix", Genres[0]),
            new Movie("The Hangover", Genres[1]),
            new Movie("The Godfather", Genres[2])
        };

        public static List<Series> Series = new List<Series>()
        {
            new Series("Game of Thrones", Genres[2]),
            new Series("Brooklyn Nine-Nine", Genres[1]),
            new Series("Breaking Bad", Genres[2])
        };

        public static List<User> Users = new List<User>()
        {
            new User() {Login = "user", Password = "user"},
            new User() {Login = "admin", Password = "admin", Role = 0}
        };
    }
}
