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
        public SelectList YearSelectList { get; set; }
        public SelectList MonthSelectList { get; set; }



        public string QueryPocket { get; set; }
        public string QueryYear { get; set; }
        public string QueryMonth { get; set; }

        public double Income { get; set; }
        public double Outcome { get; set; }
    }
}
