using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySaving.Models
{
    public class MainTransaction
    {
        public int ID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Detail { get; set; }
        public bool StatusFlag { get; set; }
        public DateTime LastUpdate { get; set; }
        public string UpdateBy { get; set; }

        //public virtual CategoryMap CategoryMapID { get; set; }
    }
}
