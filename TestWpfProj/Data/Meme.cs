using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public class Meme
    {
        public Meme(string title)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
        }

        public Meme(string title, MemeType type)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Type = type;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public MemeType? Type { get; set; }
    }
}
