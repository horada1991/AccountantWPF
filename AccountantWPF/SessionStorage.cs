using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Model;

namespace AccountantWPF
{
    public class SessionStorage
    {
        private static SessionStorage instance;

        private SessionStorage() { }

        public static SessionStorage Instance => instance ?? (instance = new SessionStorage());


        public User User { get; set; }  
    }
}
