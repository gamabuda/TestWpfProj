using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public class User
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; }

        public User(string nickname, string password)
        {
            Id = Guid.NewGuid();
            Nickname = nickname;
            Password = password;
        }
    }
}
