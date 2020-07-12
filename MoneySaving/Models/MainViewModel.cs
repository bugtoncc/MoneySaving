using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySaving.Models
{
    public class MainViewModel
    {
        public List<MainTransaction> MainTransactions { get; set; }
        public List<MPocket> Pockets { get; set; }
        public SelectList PocketsSelectList { get; set; }
        public string QueryPocket { get; set; }
    }
}
