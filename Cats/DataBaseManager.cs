using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cats
{
    public static class DataBaseManager
    {
        private static CatsDBEntities _dataBase = new CatsDBEntities();

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

        public static void RemoveCat(Cat cat)
        {
            _dataBase.Cat.Remove(cat);
            SaveChanges();
        }

        public static void EditCat(Cat NewCat)
        {
            _dataBase.Cat.AddOrUpdate(NewCat);
            SaveChanges();
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
    }
}
