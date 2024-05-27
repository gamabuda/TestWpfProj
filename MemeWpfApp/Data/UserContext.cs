using MemeWpfApp.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeWpfApp.Data
{
    internal static class UserContext
    {
        public static User AuthUser { get; set; }
    }
}

