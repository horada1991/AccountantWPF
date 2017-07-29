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
using DALayer;
using DALayer.Model;

namespace AccountantWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DALayer.DAO.IUserDao _userDao = new DALayer.DAO.Implementation.UserDaoXml();
        private SessionStorage _sessionStorage = SessionStorage.Instance;
        private Login _loginWindow;

        public MainWindow()
        {
            OpenLoginWindowIfNecessary();
            
            InitializeComponent();
        }

        private void OpenLoginWindowIfNecessary()
        {
            if (_sessionStorage.User == null)
            {
                this.Hide();
                _loginWindow = new Login(this);
                _loginWindow.Show();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
