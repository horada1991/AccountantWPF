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
        private List<User> userList;

        public void Save(User user)
        {
            userList = GetAllUser();
            if (userList.Count > 0 && userList.Find(t => t.UserName.Equals(user.UserName)) != null)
            {
                Debug.WriteLine($"UserName ({user.UserName}) is already in use.. was not saved");
                return;
            }
            userList.Add(user);
            _fileStream = new FileStream(Path.Combine(Setting.DataFolderPath, "users.xml"), FileMode.OpenOrCreate, FileAccess.Write);
            _serializerList.Serialize(_fileStream, userList);
            _fileStream.Close();
        }

        private List<User> GetAllUser()
        {
            try
            {
                _fileStream = new FileStream(Path.Combine(Setting.DataFolderPath, "users.xml"), FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine(e);
                return new List<User>();
            }
            List<User> toReturn = (List<User>)_serializerList.Deserialize(_fileStream);
            _fileStream.Close();
            return toReturn;
        }
    }
}
