using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestWpfProj.Data
{
    public class Film
    {
        public Film(string title, FilmGanr ganr)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            FilmGanr = ganr;
            //Ganr = ganr;
            //Data = data;
            //Otsenka = otsenka;
            //Picture = picture;
        }

        public Film(string title, FilmGanr ganr, DateTime data, double otsenka, string picture)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            FilmGanr = ganr;
            Data = data;
            Otsenka = otsenka;
            Picture = picture;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Ganr { get; set; }
        public DateTime Data { get; set; }
        public double Otsenka { get; set; }
        public string Picture { get; set; }
        public FilmGanr? FilmGanr { get; set; }
    }
}
