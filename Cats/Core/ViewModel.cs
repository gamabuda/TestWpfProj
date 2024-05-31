using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Cats.Service;

namespace Cats.Core
{
    public class ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string UserName
        {
            get => UserContext.CurrentUser.Nickname;
            set
            {
                _userName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserName)));
            }
        }

        private bool _isPasswordShowing = false;

        private string _userName;

        public string Password
        {
            get
            {
                var pass = "";
                for (var i = 0; i <= _userName.Length; i++)
                {
                    pass += "*";
                }

                return _isPasswordShowing ? UserContext.CurrentUser.Password : pass;
            }
            set => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
        }

        public void ShowHidePass()
        {
            _isPasswordShowing = !_isPasswordShowing;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
        }

        public void ShowPassword()
        {
            _isPasswordShowing = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
        }

        public void HidePassword()
        {
            _isPasswordShowing = false;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
        }
    }
}
