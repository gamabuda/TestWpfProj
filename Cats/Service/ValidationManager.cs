using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cats.Service
{
    public static class ValidationManager
    {
        private static Regex LettersOnlyRegex = new Regex(@"\w");
        public static bool CheckNickname(string nickName, out string ErrMessage)
        {
            switch (nickName.Length)
            {
                case < 5:
                    ErrMessage = "Имя пользователя должно содержать 5 или более символов";
                    return false;
                case > 12:
                    ErrMessage = "Имя пользователя должно содержать 12 или менее символов";
                    return false;
            }

            if (!LettersOnlyRegex.IsMatch(nickName))
            {
                ErrMessage = "Имя пользователя должно содержать только буквенные символы";
                return false;
            }

            if (DataBaseManager.IsNicknameExists(nickName))
            {
                ErrMessage = "Имя пользователя занято";
                return false;
            }

            ErrMessage = "";
            return true;
        }

        public static bool CheckPassword(string password, out string ErrMessage)
        {
            switch (password.Length)
            {
                case < 5:
                    ErrMessage = "Пароль должен состоять из 5 или более символов";
                    return false;
                case > 12:
                    ErrMessage = "Пароль должен состоять из 12 или менее символов";
                    return false;
            }

            ErrMessage = "";
            return true;
        }
    }
}
