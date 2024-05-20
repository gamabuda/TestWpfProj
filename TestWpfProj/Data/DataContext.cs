using System.Collections.Generic;

namespace TestWpfProj.Data
{
    public static class DataContext
    {
        public static List<SortType> SortTypes = new List<SortType>()
        {
            new SortType("По умолчанию"),
            new SortType("От A до Z"),
            new SortType("От Z до A"),
            new SortType("По возрастанию цены"),
            new SortType("По убыванию цены"),
        };

        public static List<MemeType> MemeTypes = new List<MemeType>()
        {
            new MemeType("Animals memes"),
            new MemeType("Tit-tok memes"),
            new MemeType("Skufs memes"),

            new MemeType("Отображение по умолчанию"),
        };

        public static List<Meme> Memes = new List<Meme>()
        {
            new Meme("Megusto", MemeTypes[2], 999),
            new Meme("bruh", MemeTypes[1], 99),
            new Meme("Omsk", MemeTypes[2], 199),
            new Meme("MalishkaHochetSdatPraktiku", MemeTypes[0], 69),
            new Meme("Sigma", MemeTypes[1], 119)
        };

        public static List<User> Users = new List<User>()
        {
            new User() { Login = "user", Password = "user" },
            new User() { Login = "admin", Password = "admin", Role = 0 },
        };
    }
}
