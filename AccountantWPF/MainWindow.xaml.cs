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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            IncomeType payment = new IncomeType {Id = Guid.NewGuid(),Name = "payment"};
            Savings savings = new Savings() {Id = Guid.NewGuid(), Name = "Hosszutav",CutFromIncomeTypes = new List<IncomeType>{payment},HasStopLimit = false,IsEmergencySavings = false,PercentageToSave = 0.1d};
            BankRoll bankRoll = new BankRoll(){Id = Guid.NewGuid(),ActualMoney = 0,LuxurySavings = 0,Name = "testBankRoll",IncomeTypes = new List<IncomeType>{payment},SavingsList = new List<Savings>{savings}};
            List<BankRoll> bankRolls = new List<BankRoll> {bankRoll};
            _userDao.Save(new User{TimeCreated = DateTime.Now, UserName = UserNameTB.Text,BankRollList = bankRolls,Id = Guid.NewGuid()});
        }
    }
}
