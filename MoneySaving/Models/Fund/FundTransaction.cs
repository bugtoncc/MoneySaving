using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneySaving.Models
{
    public class FundTransaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Display(Name = "Date")]
        public DateTime TransactionDate { get; set; }


        public int FundSummaryId { get; set; }


        [Display(Name = "Flow")]
        public int MFundFlowTypeId { get; set; }


        [Display(Name = "Fund")]
        public int MFundId { get; set; }


        public double Cost { get; set; }


        public double Nav { get; set; }


        public double Units { get; set; }


        public bool NavConfirmed { get; set; }


        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }


        public virtual IdentityUser User { get; set; }


        public virtual FundSummary FundSummary { get; set; }


        public virtual MFundFlowType MFundFlowType { get; set; }


        public virtual MFund MFund { get; set; }
    }
}
