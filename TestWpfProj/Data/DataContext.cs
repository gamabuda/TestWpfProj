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
            new MemeType("Skufs memes"),
            new MemeType("mebel")
        };

        public static List<Meme> Memes = new List<Meme>()
        {
            new Meme("Megusto", MemeTypes[2], 999),
            new Meme("bruh", MemeTypes[1], 99),
            new Meme("Omsk", MemeTypes[2], 199),
            new Meme("MalishkaHochetSdatPraktiku", MemeTypes[0], 69),
            new Meme("Sigma", MemeTypes[1], 119),
            new Meme("Stul", MemeTypes[3], 100),
            new Meme("stol", MemeTypes[3], 300),
            new Meme("hkaf", MemeTypes[3], 500),
            new Meme("kover", MemeTypes[3], 250),
            new Meme("kreslo", MemeTypes[3], 400),
            new Meme("divan", MemeTypes[3], 1000)
        };
    }
}
