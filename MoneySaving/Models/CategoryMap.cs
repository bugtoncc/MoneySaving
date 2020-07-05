using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySaving.Models
{
    public class CategoryMap
    {
        public int ID { get; set; }
        public bool StatusFlag { get; set; }
        public DateTime LastUpdate { get; set; }
        public string UpdateBy { get; set; }


        public int MCategoryId { get; set; }
        public MCategory MCategory { get; set; }
        public int MPocketId { get; set; }
        public MPocket MPocket { get; set; }
        public ICollection<MainTransaction> MainTransactions { get; set; }
    }
}
