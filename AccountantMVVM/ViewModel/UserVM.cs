using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountantMVVM.Helpers;
using DALayer.Model;

namespace AccountantMVVM.ViewModel
{
    public class UserVm : PropertyChangeHelper
    {
        private User _user = new User();

        public string Login_UserNameTb
        {
            get => _user.UserName;
            set
            {
                _user.UserName = value;
            }
        }

        // TODO look for ICOMMAND in TestCreator!
    }
}
