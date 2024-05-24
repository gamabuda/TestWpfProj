using System.Collections.Generic;

namespace TestWpfProj.Data
{
    public static class DataContext
    {
        public static List<SortType> SortTypes = new List<SortType>()
        {
            new SortType("По умолчанию"),
            new SortType("От А до Я"),
            new SortType("От Я до А"),
            new SortType("По возрастанию цены"),
            new SortType("По убыванию цены"),
            new SortType("По автору"),
        };

        public static List<BookGenre> BookGenres = new List<BookGenre>()
        {
            new BookGenre("Комедия"),
            new BookGenre("Трагедия"),
            new BookGenre("Драма"),
            new BookGenre("Роман"),
            new BookGenre("Ужасы"),
            new BookGenre("Научная фантастика"),
            new BookGenre("Детектив"),
            new BookGenre("Жанр"),

            new BookGenre("Отображение по умолчанию"),
        };

        public static List<Book> Memes = new List<Book>()
        {
            new Book("Хамелеон", BookGenres[5], 999, "Антов Чехов"),
            new Book("Сон в летнюю ночь", BookGenres[0], 999, "Уильям Шекспир"),
            new Book("Двадцать тысяч лье под водой", BookGenres[5], 999, "Жюль Верн"),
            new Book("Божественная комедия", BookGenres[1], 999, "Данте Алигьери"),
            new Book("Маленькая черная ложь", BookGenres[2], 999, "Шэрон Болтон"),
            new Book("Темная башняя", BookGenres[4], 999, "Стивен Кинг"),
            new Book("Убийства по алфавиту", BookGenres[6], 999, "Агата Кристи"),
            new Book("У меня нет рта, но я должен кричать", BookGenres[7], 599, "Харлан Эллисон"),
            new Book("День триффидов", BookGenres[4], 999, "Джон Уиндем"),
            new Book("Крепость", BookGenres[2], 999, "Валерий Карибьян"),
        };

        public static List<User> Users = new List<User>()
        {
            new User("user", "user"),
            new User("admin", "admin") { Role = 0 },
        };
    }
}
