using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EchoCraze.Properties;

namespace EchoCraze.Base
{
    public  static class Basedb
    {
        private static MusicdbEntities _dbConnection = new MusicdbEntities();

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

        public static List<Melody> GetMelodyes()
        {
            return _dbConnection.Melody.ToList();
        }

        public static bool AddMelody(Melody m)
        {
            try
            {
                _dbConnection.Melody.Add(m);
                _dbConnection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool RemoveMelody(Melody m)
        {
            try
            {
                _dbConnection.Melody.Remove(m);
                _dbConnection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<Genre> GetGenres()
        {
            return _dbConnection.Genre.ToList();
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
                _dbConnection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool AddGenre(Genre g)
        {
            try
            {
                _dbConnection.Genre.Add(g);
                _dbConnection.SaveChanges();
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
        public static List<SortType> GetSortTypes()
        {
            return _dbConnection.SortType.ToList();
        }
    }
}

