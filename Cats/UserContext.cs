using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats
{
    public static class UserContext
    {
        public static User CurrentUser { get; set; } = DataBaseManager.GetAllUsers()[0];
    }
}
