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


        public DateTime TransactionDate { get; set; }


        public int FundSummaryId { get; set; }


        public int FundFlowTypeId { get; set; }


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
    }
}
