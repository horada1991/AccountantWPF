using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Model
{
    [Serializable]
    public class BankRoll
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal ActualMoney { get; set; }
        public List<Savings> SavingsList { get; set; }
        public decimal LuxurySavings { get; set; }
        public List<IncomeType> IncomeTypes { get; set; }
    }
}
