using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public static class DataContext
    {
        public static List<MemeType> MemeTypes = new List<MemeType>()
        {
            new MemeType("Animals memes"),
            new MemeType("Tit-tok memes"),
            new MemeType("Skufs memes")
        };

        public static List<Meme> Memes = new List<Meme>()
        {
            new Meme("Megusto", MemeTypes[2], 999),
            new Meme("bruh", MemeTypes[1], 99),
            new Meme("Omsk", MemeTypes[2], 199),
            new Meme("MalishkaHochetSdatPraktiku", MemeTypes[0], 69),
            new Meme("Sigma", MemeTypes[1], 119)
        };
    }
}
