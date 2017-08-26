using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DALayer.Model;

namespace DALayer.DAO.Implementation
{
    public class UserDaoXml : IUserDao
    {
        //private readonly XmlSerializer serializerSingle = new XmlSerializer(typeof(User));
        private readonly XmlSerializer _serializerList = new XmlSerializer(typeof(List<User>));
        private FileStream _fileStream;
        private List<User> _userList;

        public void Save(User user)
        {
            _userList = GetAllUser();
            if (_userList.Count > 0 && _userList.Find(t => t.UserName.Equals(user.UserName)) != null)
            {
                Debug.WriteLine($"UserName ({user.UserName}) is already in use.. was not saved");
                return;
            }
            _userList.Add(user);
            _fileStream = new FileStream(Path.Combine(Setting.DataFolderPath, "users.xml"), FileMode.OpenOrCreate, FileAccess.Write);
            _serializerList.Serialize(_fileStream, _userList);
            _fileStream.Close();
        }

        public List<User> GetAllUser()
        {
            try
            {
                _fileStream = new FileStream(Path.Combine(Setting.DataFolderPath, "users.xml"), FileMode.Open, FileAccess.Read);
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex);
                return new List<User>();
            }
            List<User> toReturn = (List<User>)_serializerList.Deserialize(_fileStream);
            _fileStream.Close();
            return toReturn;
        }

        public User Registrate(string userName)
        {
            if (GetUserByUserName(userName) != null) return null;
            User user = new User()
            {
                BankRollList = new List<BankRoll>(),
                Id = Guid.NewGuid(),
                TimeCreated = DateTime.Now,
                UserName = userName
            };
            Save(user);

            return GetUserByUserName(userName);
        }

        public User GetUserByUserName(string userName)
        {
            return GetAllUser().Find(u => u.UserName.Equals(userName));
        }
    }
}
