using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Cats.Core;

namespace Cats.Service
{
    public static class UserContext
    {
        public static User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                Update();
            }
        }

        private static User _currentUser = DataBaseManager.GetAllUsers()[0];

        public static ViewModel AppViewModel = new();

        public static void Guest()
        {
            CurrentUser = DataBaseManager.GetAllUsers().First(x => x.ID == "GUEST");
        }

        public static void Update()
        {
            if (UserContext.CurrentUser == null) return;
            AppViewModel.UserName = CurrentUser.Nickname;
            AppViewModel.Password = CurrentUser.Password;
        }
    }
}
