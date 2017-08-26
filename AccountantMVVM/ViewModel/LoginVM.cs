using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AccountantMVVM.Helpers;
using AccountantMVVM.Service;
using DALayer.Model;

namespace AccountantMVVM.ViewModel
{
    public class LoginVM : PropertyChangeHelper
    {
        private User _user = new User();
        private readonly UserService _userService = UserService.Instance;
        private string _infoMessage = String.Empty;

        public string Login_UserNameTb
        {
            get => _user.UserName;
            set
            {
                _user.UserName = value;
            }
        }

        public string InfoMessage => _infoMessage;

        #region button clicks

        private ICommand _loginClicked;

        public ICommand LoginClicked => _loginClicked ?? (_loginClicked = new CommandHandler(Login));

        private void Login(object parameter)
        {
            var response = _userService.LogIn(_user.UserName);
            if (response.User == null)
            {
                _infoMessage = "Unsuccessful log in!";
                return;
            }
            _user = response.User;

            MainWindow newMainWindow = new MainWindow();
            try
            {
                ((MainVM) newMainWindow.FindResource("MainViewModel")).ActualUser = _user;
            }
            catch (ResourceReferenceKeyNotFoundException ex)
            {
                Console.WriteLine(ex);
            }

            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window.Title == "Login")
                {
                    window.Close();
                }
            }

            newMainWindow.Show();
        }

        #endregion
    }
}
