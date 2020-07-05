using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySaving.Models
{
    public class MPocket
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool StatusFlag { get; set; }
        public DateTime LastUpdate { get; set; }
        public string UpdateBy { get; set; }

        public List<CategoryMap> CategoryMaps { get; set; }
    }
}
