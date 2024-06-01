using MemeWpfApp.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeWpfApp.Data
{
    internal static class DataBaseManager
    {
        private static HomeManagerEntities _dbConnection = new HomeManagerEntities();

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

        public static List<HomeItem> GetHomeItems()
        {
            return _dbConnection.HomeItem.ToList();
        }

        public static bool AddHomeItem(HomeItem m)
        {
            try
            {
                _dbConnection.HomeItem.Add(m);
                UpdateDatabase();
                return true;
            }
            catch {
                return false;
            }
        }

        public static bool RemoveHomeItem(HomeItem m)
        {
            try
            {
                _dbConnection.HomeItem.Remove(m);
                UpdateDatabase();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<HomeItemType> GetHomeItemTypes()
        {
            return _dbConnection.HomeItemType.ToList();
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
