using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cats.Service;

namespace Cats.Pages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private bool _isNicknameChanging;
        private bool _isPasswordChanging;
        public ProfilePage()
        {
            InitializeComponent();
            DataContext = UserContext.AppViewModel;
        }

        private void NicknameChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            var newNickname = NicknameTb.Text;
            if (_isNicknameChanging)
            {
                if (newNickname != UserContext.CurrentUser.Nickname)
                {
                    if (!ValidationManager.CheckNickname(newNickname, out var errMessage))
                    {
                        MessageBox.Show(errMessage);
                        return;
                    }

                    UserContext.CurrentUser.Nickname = newNickname;
                    DataBaseManager.UpdateUser(UserContext.CurrentUser);
                }
            }
            NicknameLbl.Visibility = _isNicknameChanging ? Visibility.Visible : Visibility.Collapsed;
            NicknameTb.Visibility = _isNicknameChanging ? Visibility.Collapsed : Visibility.Visible;
            NicknameTb.Focus();
            _isNicknameChanging = !_isNicknameChanging;
        }

        private void ShowPass_OnClick(object sender, RoutedEventArgs e)
        {
            UserContext.AppViewModel.ShowHidePass();
        }

        private void PasswordChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            var newPassword = PasswordTb.Text;
            UserContext.AppViewModel.ShowPassword();
            ShowPass.IsEnabled = false;
            if (_isPasswordChanging)
            {
                if (newPassword != UserContext.CurrentUser.Password)
                {
                    if (!ValidationManager.CheckPassword(newPassword, out var errMessage))
                    {
                        MessageBox.Show(errMessage);
                        return;
                    }

                    UserContext.CurrentUser.Password = newPassword;
                    DataBaseManager.UpdateUser(UserContext.CurrentUser);
                }
                UserContext.AppViewModel.HidePassword();
                ShowPass.IsEnabled = true;
            }
            PasswordLbl.Visibility = _isPasswordChanging ? Visibility.Visible : Visibility.Collapsed;
            PasswordTb.Visibility = _isPasswordChanging ? Visibility.Collapsed : Visibility.Visible;
            PasswordTb.Focus();
            _isPasswordChanging = !_isPasswordChanging;
        }
    }
}
