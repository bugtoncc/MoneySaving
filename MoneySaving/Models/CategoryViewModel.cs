using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MoneySaving.Models
{
    public class CategoryViewModel
    {
        public List<MCategory> Categories { get; set; }
        public SelectList CashflowTypeName { get; set; }
        public string CategoryCashflowType { get; set; }
        public string SearchString { get; set; }
    }
}
