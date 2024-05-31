using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameWpfApp.DbConnection;

namespace GameWpfApp.Data
{
    internal static class DataBaseManager
    {
        private static GamesdbEntities _dbConnection = new GamesdbEntities();

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

        public static List<Game> GetGames()
        {
            return _dbConnection.Game.ToList();
        }

        public static bool AddGame(Game m)
        {
            try
            {
                _dbConnection.Game.Add(m);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool RemoveGame(Game m)
        {
            try
            {
                _dbConnection.Game.Remove(m);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<GameType> GetGameTypes()
        {
            return _dbConnection.GameType.ToList();
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