using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public static class DataContext
    {
        public static List<FilmGanr> FilmGanres = new List<FilmGanr>()
        {
            new FilmGanr("Romantic"),
            new FilmGanr("Comedia"),
            new FilmGanr("Detectiv")
        };

        public static List<Film> Films = new List<Film>()
        {
            new Film("Posle", FilmGanres[0], new DateTime(2022,2,2), 5.8,""),
            new Film("Sled", FilmGanres[2], new DateTime(2018,1,3), 8.1,""),
            new Film("Do rastveta", FilmGanres[1], new DateTime(2020,12,10), 9.5,""),
            new Film("MalishkaHochetSdatPraktiku", FilmGanres[0], new DateTime(2003,1,7), 9.9,""),
            new Film("4 Zakon", FilmGanres[1], new DateTime(1875,2,4), 4.4,"")
        };
    }
}
