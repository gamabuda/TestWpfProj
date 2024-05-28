using System.Collections.Generic;
using System.Linq;
using WPFProjectDB.DataBaseConnection;

namespace WPFProjectDB.Data
{
    internal static class DataBaseManager
    {
        private static WPFProjectDBEntities _dataBase = new WPFProjectDBEntities();

        public static List<Users> GetUsers()
        {
            return _dataBase.Users.ToList();
        }
        public static bool AddUser(Users user)
        {
            try
            {
                _dataBase.Users.Add(user);
                _dataBase.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool RemoveUser(Users user)
        {
            try
            {
                _dataBase.Users.Remove(user);
                _dataBase.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateUser(Users user)
        {
            try
            {
                _dataBase.Entry(user).State = System.Data.Entity.EntityState.Modified;
                _dataBase.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static List<LanguageType> GetLanguageTypes()
        {
            return _dataBase.LanguageType.ToList();
        }
        public static bool AddLanguageType(LanguageType languageType)
        {
            try
            {
                _dataBase.LanguageType.Add(languageType);
                _dataBase.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool RemoveLanguageType(LanguageType languageType)
        {
            try
            {
                _dataBase.LanguageType.Remove(languageType);
                _dataBase.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateLanguageType(LanguageType languageType)
        {
            try
            {
                _dataBase.Entry(languageType).State = System.Data.Entity.EntityState.Modified;
                _dataBase.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static List<Languages> GetLanguages()
        {
            return _dataBase.Languages.ToList();
        }
        public static bool AddLanguage(Languages language)
        {
            try
            {
                _dataBase.Languages.Add(language);
                _dataBase.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool RemoveLanguage(Languages language)
        {
            try
            {
                _dataBase.Languages.Remove(language);
                _dataBase.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateLanguage(Languages language)
        {
            try
            {
                _dataBase.Entry(language).State = System.Data.Entity.EntityState.Modified;
                _dataBase.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateDatabase()
        {
            try
            {
                _dataBase.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
