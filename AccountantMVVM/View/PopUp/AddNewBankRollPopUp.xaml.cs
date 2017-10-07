using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace AccountantMVVM
{
    /// <summary>
    /// Interaction logic for AddNewBankRoll.xaml
    /// </summary>
    public partial class AddNewBankRollPopUp : Window
    {
        private string _bankRollName = null;
        private decimal _actualMoney = 0;

        public string BankRollName
        {
            get => _bankRollName;
            set
            {
                _bankRollName = value;
                NewBankRollNameTxtBox.Text = _bankRollName;
            }
        }
        public decimal ActualMoney
        {
            get => _actualMoney;
            set
            {
                _actualMoney = value;
                ActualMoneyTxtBox.Text = _actualMoney.ToString(CultureInfo.InvariantCulture);
            }
        }

        public AddNewBankRollPopUp()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            SaveBtn.IsEnabled = false;
        }

        private void ActualMoneyTxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            BankRollName = null;
            ActualMoney = 0;
            this.Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            BankRollName = NewBankRollNameTxtBox.Text;
            ActualMoney = decimal.Parse(ActualMoneyTxtBox.Text);
            this.Close();
        }

        private void NewBankRollNameTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox) sender).Text.Length < 4)
            {
                InfoLabel.Content = "Bankroll name is too short.\nPlease use at least 4 character";
                SaveBtn.IsEnabled = false;
            }
            else
            {
                InfoLabel.Content = "";
                SaveBtn.IsEnabled = true;
            }
        }
    }
}
