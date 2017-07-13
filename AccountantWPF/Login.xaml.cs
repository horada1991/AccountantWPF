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

namespace AccountantWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private bool _userNameInputTB_GotFocus = false;

        public Login()
        {
            InitializeComponent();
        }

        private void UserNameInputTB_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!_userNameInputTB_GotFocus)
            {
                UserNameInputTB.Text = "";
                _userNameInputTB_GotFocus = true;
            }
        }
    }
}
