using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySaving.Models
{
    public class Pocket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PocketID { get; set; }
        public string Name { get; set; }

        public string TestColumnString { get; set; }
        public int TestColumnNumber { get; set; }


        public DateTime LastUpdate { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
