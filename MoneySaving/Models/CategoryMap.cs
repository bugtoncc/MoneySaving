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

        //public virtual MCategory MCategoryID { get; set; }
        //public virtual MPocket MPocketID { get; set; }
        //public virtual ICollection<MainTransaction> MainTransactionsID { get; set; }
    }
}
