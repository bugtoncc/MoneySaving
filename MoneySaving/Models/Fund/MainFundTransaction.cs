using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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


        [Display(Name = "Fund")]
        public int MFundId { get; set; }


        [Display(Name = "Flow")]
        public string MFundFlowTypeId { get; set; }


        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }


        [Display(Name = "Port")]
        public int FundPortId { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Currency)]
        public double Cost { get; set; }


        [Required(ErrorMessage = "*")]
        public double Nav { get; set; }


        [Required(ErrorMessage = "*")]
        public double Units { get; set; }
    }
}
