using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Model;

namespace DALayer.DAO
{
    public interface IUserDao
    {
        void Save(User user);
        User GetUserByUserName(string userName);
        List<User> GetAllUser();
        User Registrate(string userName);
    }
}
