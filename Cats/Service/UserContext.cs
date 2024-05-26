using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cats.Core;

namespace Cats
{
    public static class UserContext
    {
        public static User CurrentUser { get; set; } = DataBaseManager.GetAllUsers()[0];

        public static void Guest()
        {
            CurrentUser = DataBaseManager.GetAllUsers().First(x => x.ID == "GUEST");
        }
    }
}
