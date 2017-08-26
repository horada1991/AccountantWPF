using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Model;

namespace AccountantMVVM.Helpers
{
    public class ResponseHelper
    {
        public User User { get; set; }
        public List<string> Info { get; set; }
        public List<string> Error { get; set; }

        public ResponseHelper()
        {
            Info = new List<string>();
            Error = new List<string>();
        }
    }
}
