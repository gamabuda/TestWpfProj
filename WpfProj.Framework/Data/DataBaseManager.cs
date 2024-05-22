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

namespace WpfProj.Framework.Data
{
    internal static class DataBaseManager
    {
        private static DataBaseEntities _dataBase = new DataBaseEntities();

        public static List<User> GetUsers(Expression<Func<User, bool>> filter)
        {
            return _dataBase.User.ToList();
        }

        public static List<Meme> GetMemes()
        {
            return _dataBase.Meme.ToList();
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
