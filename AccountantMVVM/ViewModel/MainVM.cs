using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using AccountantMVVM.Helpers;
using AccountantMVVM.Service;
using AccountantMVVM.View.PopUp;
using DALayer.Model;

namespace AccountantMVVM.ViewModel
{
    public class MainVM : PropertyChangeHelper
    {
        private User _user = new User();
        private BankRoll _selectedBankRoll;
        private readonly UserService _userService = UserService.Instance;

        public User ActualUser
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged("ActualUser");
            }
        }

        public BankRoll SelectedBankRoll
        {
            get
            {
                if (_selectedBankRoll == null)
                {
                    _selectedBankRoll = _user.BankRollList.FirstOrDefault();
                }
                return _selectedBankRoll;
            }
            set
            {
                _selectedBankRoll = value;
                OnPropertyChanged("SelectedBankRoll");
            }
        }

        #region MenuBar Items Click
        private ICommand _addNewBankRollClicked;

        public ICommand AddNewBankRollClicked => _addNewBankRollClicked ?? (_addNewBankRollClicked = new CommandHandler(AddNewBankRoll));

        private void AddNewBankRoll(object parameter)
        {
            AddNewBankRoll();
        }

        private void AddNewBankRoll(AddNewBankRollPopUp bankRollPopUp = null)
        {
            AddNewBankRollPopUp popUp = new AddNewBankRollPopUp();
            if (bankRollPopUp != null)
            {
                popUp.ActualMoney = bankRollPopUp.ActualMoney;
                popUp.BankRollName = bankRollPopUp.BankRollName;
            }
            popUp.ShowDialog();

            if (popUp.BankRollName == null)
            {
                Console.WriteLine(@"Add new bankRoll cancelled");
                return;
            }

            var response = _userService.AddNewBankoll(_user, popUp.BankRollName, popUp.ActualMoney);
            response.HandleResponse();

            if (response.Error.Count > 0)
            {
                AddNewBankRoll(popUp);
            }
        }
        #endregion
    }
}
