using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public class RetroGame
    {
        public RetroGame(string title)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
        }

        public RetroGame(string title, GameType type)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            GameType = type;
        }

        public RetroGame(string title, GameType type, decimal price)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            GameType = type;
            Price = price;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public GameType? GameType { get; set; }
        public decimal Price { get; set; } = 0;
    }
}
