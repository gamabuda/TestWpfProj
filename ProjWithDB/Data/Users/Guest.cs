using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjWithDB.Data.Users
{
    public class Guest : User
    {
        public Guest(string name, string password) : base(name, password)
        {
        }
    }
}
