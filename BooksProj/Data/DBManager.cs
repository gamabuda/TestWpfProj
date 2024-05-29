using BooksProj.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksProj.Data
{
    internal class DBManager
    {
        private static bookDBEntity _dbConnection = new bookDBEntity();

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

        public static List<Book> GetBooks()
        {
            return _dbConnection.Book.ToList();
        }

        public static bool AddBook(Book b)
        {
            try
            {
                _dbConnection.Book.Add(b);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool RemoveBook(Book b)
        {
            try
            {
                _dbConnection.Book.Remove(b);
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

        public static List<Sorts> GetSorts()
        {
            return _dbConnection.Sorts.ToList();
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
