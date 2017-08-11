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
using System.Windows.Shapes;
using DALayer.Model;
//using Service;
//using Service.Helpers;

namespace AccountantMVVM
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        //private readonly UserService _userService = new UserService();
        private readonly MainWindow _mainWindow;
        //private ResponseHelper _response = new ResponseHelper();

        public Login(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void LoginUserBtn_Click(object sender, RoutedEventArgs e)
        {
            //_response = _userService.LogIn(UserNameInputTB.Text);
            //if (_response.User == null)
            //{
            //    infoMessageLabel.Content = "Unsuccessful log in!";
            //    return;
            //}

            //SessionStorage sessionStorage = SessionStorage.Instance;
            //sessionStorage.User = _response.User;
            //_mainWindow.Label1.Content = sessionStorage.User.UserName;
            //_mainWindow.Label2.Content = sessionStorage.User.Id;
            //_mainWindow.Label3.Content = sessionStorage.User.TimeCreated;
            //_mainWindow.Show();
            //this.Close();
        }
    }
}
