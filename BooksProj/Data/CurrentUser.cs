using BooksProj.DbConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksProj.Data
{
    internal static class CurrentUser
    {
        public static User currentUser { get; set; } 
    }
}
