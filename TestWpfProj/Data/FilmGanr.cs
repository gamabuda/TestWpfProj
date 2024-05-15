using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace TestWpfProj.Data
{
    public class FilmGanr
    {
        public FilmGanr(string title)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
        }

        public string Id { get; set; }
        public string Title { get; set; }
    }
}
