using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.DAO;
using DALayer.DAO.Implementation;
using DALayer.Model;
using Service.Helpers;

namespace Service
{
    public class UserService
    {
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
    }
}
