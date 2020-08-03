using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySaving.Models
{
    public class MainFundModel
    {
        public List<MFund> MFunds { get; set; }

        public SelectList AmcSelectList { get; set; }
        public SelectList AmcSelectListFilter { get; set; }

        public string QueryAmc { get; set; }
    }
}
