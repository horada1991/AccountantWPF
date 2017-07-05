using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Model
{
    public class Savings
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double PercentageToSave { get; set; }
        public bool HasStopLimit { get; set; }
        public decimal StopLimit { get; set; }
        public bool IsEmergencySavings { get; set; }
        public List<IncomeType> CutFromIncomeTypes { get; set; }
    }
}
