using System;
using System.Collections.Generic;
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

        public static void AddCat(Cat cat)
        {
            _dataBase.Cat.Add(cat);
            _dataBase.SaveChanges();
        }
    }
}
