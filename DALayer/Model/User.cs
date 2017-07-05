﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Model
{
    [Serializable]
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime TimeCreated { get; set; }
        public List<BankRoll> BankRollList { get; set; }
    }
}
