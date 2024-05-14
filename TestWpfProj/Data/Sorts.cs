using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestWpfProj.Data
{
    public struct Sort
    {
        public string Name { get; set; }
        public Func<List<Meme>, List<Meme>> Action { get; set; }
    }

    public static class Sorts
    {
        public static List<Sort> SortList = new()
        {
            new Sort() { Name="None", Action=(List<Meme> a) => a},
            new Sort() { Name="Alphabetical", Action=(List<Meme> a) => a.OrderBy(s => s.Title).ToList() },
            new Sort() { Name="AlphabeticalReverse", Action=(List<Meme> a) =>  a.OrderBy(s => s.Title).Reverse().ToList() },
            new Sort() { Name="ByPrice", Action=(List<Meme> a) => a.OrderBy(s => s.Price).ToList() },
            new Sort() { Name="ByPriceReversed", Action=(List<Meme> a) => a.OrderBy(s => s.Price).Reverse().ToList() },
        };
    }
}
