using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjWithDB.Data
{
    internal class DBManager
    {
        private static ChildrenHomeEntities _dbConnection = new ChildrenHomeEntities();

        public static bool UpdateDatabase()
        {
            try
            {
                _dbConnection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool RemoveUser(User u)
        {
            try
            {
                _dbConnection.User.Remove(u);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<User> GetUsers()
        {
            return _dbConnection.User.ToList();
        }

        public static bool AddUser(User u)
        {
            try
            {
                _dbConnection.User.Add(u);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<Role> GetRoles()
        {
            return _dbConnection.Role.ToList();
        }
    }
}
