using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneySaving.Models
{
    public class FundSummary
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        public int FundPortId { get; set; }


        public int MFundId { get; set; }


        public double Cost { get; set; }


        public double Unit { get; set; }


        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }


        public virtual IdentityUser User { get; set; }


        //public virtual MFund MFund { get; set; }


        public List<FundTransaction> FundTransactions { get; set; }


        public virtual FundPort FundPort { get; set; }
    }
}
