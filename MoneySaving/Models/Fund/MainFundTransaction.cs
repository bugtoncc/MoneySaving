using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MoneySaving.Models
{
    public class MainFundTransaction
    {
        public List<FundTransaction> FundTransactions { get; set; }

        //public SelectList AmcSelectList { get; set; }
        public SelectList FundSelectListFilter { get; set; }
        public SelectList FundFlowTypeSelectListFilter { get; set; }

        //public string QueryAmc { get; set; }
        public string QueryFundKeyword { get; set; }

        public string QueryFundSelected { get; set; }

        public string QueryFundFlowSelected { get; set; }
    }
}
