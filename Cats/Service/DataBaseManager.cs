using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Cats.Core;
using Cats.Service;
using Microsoft.Win32;

namespace Cats
{
    public static class DataBaseManager
    {
        private static CatsDBEntities _dataBase = new CatsDBEntities();

        public static bool CanLogin(string login, string password, out User user)
        {
            var users = _dataBase.User;
            user = users.FirstOrDefault(x => x.Nickname.Trim() == login.ToLower());
            if (user == null)
            {
                MessageBox.Show("Аккаунта с таким логином не существует! \nПопробуйте создать новый аккаунт");
                return false;
            }

            if (user.Password.Trim() != password)
            {
                MessageBox.Show("Неверный пароль! \nПопробуйте еще");
                return false;
            }

            MessageBox.Show("Успешно!");
            return true;
        }

        public static bool CanRegister(string login, string password, out User user)
        {
            var users = _dataBase.User.ToList();
            user = users.FirstOrDefault(x => x.Nickname == login);
            if (user == null)
            {
                MessageBox.Show("Успешно!");
                user = new User() { ID = Guid.NewGuid().ToString(), isAdmin = false, Nickname = login, Password = password};
                return true;
            }

            MessageBox.Show("Логин занят!");
            return false; 
        }

        public static void AddUser(User user)
        {
            _dataBase.User.Add(user);
            SaveChanges();
        }
        public static List<Cat> GetAllCats()
        {
            return _dataBase.Cat.ToList();
        }

        public static List<CatType> GetAllCatTypes()
        {
            return _dataBase.CatType.ToList();
        }

        public static List<User> GetAllUsers()
        {
            return _dataBase.User.ToList();
        }

        public static void AddCat(Cat cat)
        {
            _dataBase.Cat.Add(cat);
            SaveChanges();
        }

        public static void AddCatType(CatType catType)
        {
            _dataBase.CatType.Add(catType);
            SaveChanges();
        }

        public static void RemoveCatType(CatType catType)
        {
            _dataBase.CatType.Remove(catType);
            SaveChanges();
        }

        public static void UpdateCatType(CatType catType)
        {
            _dataBase.CatType.AddOrUpdate(catType);
            SaveChanges();
        }
        public static void RemoveCat(Cat cat)
        {
            _dataBase.Cat.Remove(cat);
            SaveChanges();
        }

        public static void UpdateCat(Cat NewCat)
        {
            _dataBase.Cat.AddOrUpdate(NewCat);
            SaveChanges();
        }

        public static void UpdateUser(User user)
        {
            _dataBase.User.AddOrUpdate(user);
            SaveChanges();
            UserContext.Update();
        }
        public static void SaveChanges()
        {
            try
            {
                _dataBase.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var f in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} fail validation\n", f.Entry.Entity.GetType());
                    foreach (var err in f.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", err.PropertyName, err.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Fail: " + sb.ToString(), ex);
            }
        }

        public static bool IsNicknameExists(string nickName)
        {
            return _dataBase.User.Any(x => x.Nickname.ToLower() == nickName.ToLower());
        }
    }
}
