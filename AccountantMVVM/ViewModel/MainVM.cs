using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountantMVVM.Helpers;
using DALayer.Model;

namespace AccountantMVVM.ViewModel
{
    public class MainVM : PropertyChangeHelper
    {
        private User _user = new User();

        public User ActualUser
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged("ActualUser");
            }
        }
    }
}
