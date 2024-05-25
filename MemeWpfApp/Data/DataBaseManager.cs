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
        private static MemesDbEntities _dbConnection = new MemesDbEntities();

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

        public static List<Meme> GetMemes()
        {
            return _dbConnection.Meme.ToList();
        }

        public static bool AddMeme(Meme m)
        {
            try
            {
                _dbConnection.Meme.Add(m);
                return true;
            }
            catch {
                return false;
            }
        }

        public static bool RemoveMeme(Meme m)
        {
            try
            {
                _dbConnection.Meme.Remove(m);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<MemeType> GetMemeTypes()
        {
            return _dbConnection.MemeType.ToList();
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
