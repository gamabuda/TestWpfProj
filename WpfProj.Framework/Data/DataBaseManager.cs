using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WpfProj.Framework.DbConnection;
using System.Data;

namespace WpfProj.Framework.Data
{
    internal static class DataBaseManager
    {
        private static DbConectionEntities _dbConection = new DbConectionEntities();

        public static bool UpdateDatabase()
        {
            try
            {
                _dbConection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<Film> GetMemes()
        {
            return _dbConection.Film.ToList();
        }

        public static bool AddMeme(Film m)
        {
            try
            {
                _dbConection.Film.Add(m);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool RemoveMeme(Film m)
        {
            try
            {
                _dbConection.Film.Remove(m);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<FilmGanr> GetMemeTypes()
        {
            return _dbConection.FilmGanr.ToList();
        }

        public static List<User> GetUsers()
        {
            return _dbConection.User.ToList();
        }

        public static bool AddUser(User u)
        {
            try
            {
                _dbConection.User.Add(u);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public static List<Role> GetRoles()
        //{
        //    return _dbConection.Role.ToList();
        //}
    }
}