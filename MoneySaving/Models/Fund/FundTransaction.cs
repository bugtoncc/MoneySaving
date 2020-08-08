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
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }


        [Display(Name = "Portfolio")]
        public int FundPortId { get; set; }


        [Display(Name = "Type")]
        public int MFundFlowTypeId { get; set; }


        [Display(Name = "Fund")]
        public int MFundId { get; set; }


        [Required(ErrorMessage = "*")]
        public double Cost { get; set; }


        [Required(ErrorMessage = "*")]
        public double Nav { get; set; }


        [Required(ErrorMessage = "*")]
        public double Units { get; set; }


        [Display(Name = "NAV Confirmed")]
        public bool NavConfirmed { get; set; }


        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }


        public virtual IdentityUser User { get; set; }


        [Display(Name = "Port")]
        public virtual FundPort FundPort { get; set; }


        [Display(Name = "Type")]
        public virtual MFundFlowType MFundFlowType { get; set; }


        [Display(Name = "Fund")]
        public virtual MFund MFund { get; set; }


        public FundTransaction()
        {
            TransactionDate = DateTime.Now;
            LastUpdate = DateTime.Now;
        }
    }
}
