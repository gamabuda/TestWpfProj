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
        public Func<List<Cat>, List<Cat>> Action { get; set; }
    }

    public static class Sorts
    {
        public static List<Sort> SortList = new()
        {
            new Sort() { Name="None", Action=(List<Cat> a) => a},
            new Sort() { Name="Alphabetical", Action=(List<Cat> a) => a.OrderBy(s => s.Name).ToList() },
            new Sort() { Name="AlphabeticalReverse", Action=(List<Cat> a) =>  a.OrderBy(s => s.Name).Reverse().ToList() },
            new Sort() { Name="ByBirthday", Action=(List<Cat> a) => a.OrderBy(s => s.Birthday).ToList() },
            new Sort() { Name="ByBirthdayReversed", Action=(List<Cat> a) => a.OrderBy(s => s.Birthday).Reverse().ToList() },
        };
    }
}
