using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Model;

namespace DALayer.DAO
{
    interface IBankRollDao
    {
        void Save(BankRoll bankRoll);
        BankRoll GetBankRollById();
        List<BankRoll> GetAllBankRolls();
    }
}
