using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySaving.Models
{

    public enum Type
    {
        Income, Outcome
    }

    public class Category
    {        
        public int CategoryID { get; set; }
        public int PocketId { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Pocket Pocket { get; set; }
    }
}
