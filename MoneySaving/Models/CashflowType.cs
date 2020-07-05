using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySaving.Models
{
    public class CashflowType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool StatusFlag { get; set; }
        public DateTime LastUpdate { get; set; }
        public string UpdateBy { get; set; }

        public List<MCategory> MCategories { get; set; }
    }
}
