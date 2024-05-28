using BooksProj.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksProj.Data
{
    public static class CurrentUser
    {
        public static User currentUser { get; set; } 
    }
}
