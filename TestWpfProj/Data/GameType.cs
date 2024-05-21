﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public class GameType
    {
        public GameType(string title)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
        }

        public string Id { get; set; }
        public string Title { get; set; }
    }
}
