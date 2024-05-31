using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjWithDB.Data
{
    internal class DBManager
    {

        private static ChildrenHomeEntities _context = new ChildrenHomeEntities();
        public static ChildrenHomeEntities GetContext()
        {
            if (_context == null)
                _context = new ChildrenHomeEntities();
            return _context;
        }
        public static bool UpdateDatabase()
        {
            try
            {
                _context.SaveChanges();
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
                _context.User.Remove(u);
                UpdateDatabase();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<User> GetUsers()
        {
            return _context.User.ToList();
        }

        public static bool AddUser(User u)
        {
            try
            {
                _context.User.Add(u);
                UpdateDatabase();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<Role> GetRoles()
        {
            return _context.Role.ToList();
        }

        public static bool AddRole(Role r)
        {
            try
            {
                _context.Role.Add(r);
                UpdateDatabase();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<Child> GetChild()
        {
            return _context.Child.ToList();
        }

        public static bool RemoveChild(Child c)
        {
            try
            {
                _context.Child.Remove(c);
                UpdateDatabase();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
