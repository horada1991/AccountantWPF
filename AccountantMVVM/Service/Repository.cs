using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using DALayer.DAO;
using DALayer.DAO.Implementation;
using DALayer.Model;

namespace AccountantMVVM.Service
{
    class Repository
    {
        private readonly IUserDao _userDao = new UserDaoXml();

        private static Repository _instance;

        private Repository() { }

        public static Repository Instance => _instance ?? (_instance = new Repository());

        public List<User> Users;

        public void FillUpRepository()
        {
            this.Users = _userDao.GetAllUser();
        }

        public User GetUserByUserName(string userName)
        {
            return Users.Find(u => u.UserName.Equals(userName));
        }

        public User Registrate(string userName)
        {
            User user = _userDao.Registrate(userName);
            Users.Add(user);
            return user;
        }
    }
}
