using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data.Users
{
    public class User
    {
        public User(string login, string password)
        {
            Id = Guid.NewGuid().ToString();
            Login = login;
            Password = password;
        }

        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
