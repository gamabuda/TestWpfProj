using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; } = 1;
    }
}
