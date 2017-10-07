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
using AccountantMVVM.Service;
using AccountantMVVM.ViewModel;
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
        public Login()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            LoginUserBtn.IsEnabled = false;

            //for testing
            //UserNameInputTB.Text = "Cerianth";
            //var viewModel = (LoginVM)FindResource("UserViewModel");
            //if (viewModel == null)
            //{
            //    Console.WriteLine(@"Couldn't get viewmodel when Enter is pressed!");
            //    return;
            //}
            //if (viewModel.LoginClicked.CanExecute(null))
            //    viewModel.LoginClicked.Execute(null);
        }

        private void UserNameInputTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox) sender).Text.Length < 4)
            {
                LoginUserBtn.IsEnabled = false;
                infoMessageLabel.Content = "Please give me a User Name with at least 4 character in it!";
            }
            else
            {
                LoginUserBtn.IsEnabled = true;
                infoMessageLabel.Content = "";
            }
        }

        private void UserNameInputTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && UserNameInputTB.Text.Length > 3)
            {
                var viewModel = (LoginVM)FindResource("UserViewModel");
                if (viewModel == null)
                {
                    Console.WriteLine(@"Couldn't get viewmodel when Enter is pressed!");
                    return;
                }
                if(viewModel.LoginClicked.CanExecute(null))
                    viewModel.LoginClicked.Execute(null);
            }
        }
    }
}
