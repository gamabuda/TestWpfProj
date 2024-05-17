using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public static class DataContext
    {
        public static List<LanguageType> LanguageTypes = new List<LanguageType>()
        {
            new LanguageType("For young developers"),
            new LanguageType("For middle developers"),
            new LanguageType("For professional developers")
        };

        public static List<Language> Languages = new List<Language>()
        {
            new Language("C#", LanguageTypes[0], 999),
            new Language("Ruby", LanguageTypes[1], 99),
            new Language("JavaScript", LanguageTypes[2], 199),
            new Language("HelpMEidklangugesExepct1C", LanguageTypes[2], 69),
            new Language("HTML", LanguageTypes[0], 119)
        };
    }
}
