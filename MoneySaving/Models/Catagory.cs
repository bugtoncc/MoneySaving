using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySaving.Models {
    public class Catagory {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PocketID { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
