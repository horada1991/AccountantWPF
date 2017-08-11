using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Model;

namespace AccountantMVVM
{
    public class SessionStorage
    {
        private static SessionStorage _instance;

        private SessionStorage() { }

        public static SessionStorage Instance => _instance ?? (_instance = new SessionStorage());
        
        public User User { get; set; }  
    }
}
