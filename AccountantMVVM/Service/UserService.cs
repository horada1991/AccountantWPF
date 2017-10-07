using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AccountantMVVM.Helpers;
using DALayer.DAO;
using DALayer.DAO.Implementation;
using DALayer.Model;

namespace AccountantMVVM.Service
{
    public class UserService
    {
        private static UserService _instance;

        private UserService() { }

        public static UserService Instance => _instance ?? (_instance = new UserService());
        
        private readonly IUserDao _userDao = new UserDaoXml();

        public ResponseHelper LogIn(string userName)
        {
            ResponseHelper response = new ResponseHelper {User = _userDao.GetUserByUserName(userName)};
            if (response.User == null)
            {
                response.Info.Add($"Registering new user");
                response.User = _userDao.Registrate(userName);
                response.Info.Add(response.User != null ? "Successfull registration" : $"Unsuccessfull registration");
            }

            return response;
        }

        public ResponseHelper FindUserByUserName(string userName)
        {
            ResponseHelper response = new ResponseHelper {User = _userDao.GetUserByUserName(userName)};
            response.Info.Add(response.User == null ? "User not found" : "User founded");
            return response;
        }

        public ResponseHelper AddNewBankoll(User user, string bankRollName, decimal actualMoney)
        {
            ResponseHelper response = new ResponseHelper();
            if (user.BankRollList?.FirstOrDefault(b => b.Name.Equals(bankRollName)) != null)
            {
                response.Error.Add($"There's already a bankroll with the given name: {bankRollName}");
                return response;
            }

            Guid id = Guid.NewGuid();
            BankRoll bankRoll = new BankRoll
            {
                Id = id,
                Name = bankRollName,
                ActualMoney = actualMoney,
                IncomeTypes = new List<IncomeType>(),
                LuxurySavings = 0,
                SavingsList = new List<Savings>()
            };

            if (user.BankRollList == null) user.BankRollList = new List<BankRoll>();
            user.BankRollList.Add(bankRoll);
            _userDao.Save(user);
            User savedUser = _userDao.GetUserByUserName(user.UserName);
            if (savedUser.BankRollList.FirstOrDefault(b => b.Name.Equals(bankRoll.Name) && b.Id == id &&
                                                           b.ActualMoney == actualMoney) == null)
            {
                response.Error.Add($"Failed to save Bankroll ({bankRollName}) to user: {user.UserName}");
                return response;
            }

            response.Info.Add($"Successfully saved Bankroll ({bankRollName}) to user: {user.UserName}");
            return response;
        }
    }
}
