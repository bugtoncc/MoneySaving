using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneySaving.Models
{
    public class MFund
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Display(Name = "Name TH")]
        [Required(ErrorMessage = "*")]
        public string NameTh { get; set; }


        [Display(Name = "Name EN")]
        [Required(ErrorMessage = "*")]
        public string NameEn { get; set; }


        [Display(Name = "Abbr.")]
        [Required(ErrorMessage = "*")]
        public string Abbr { get; set; }


        [Display(Name = "Project Id")]
        [Required(ErrorMessage = "*")]
        public string ProjectId { get; set; }


        [Display(Name = "Register Id")]
        [Required(ErrorMessage = "*")]
        public string RegisId { get; set; }


        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "*")]
        public DateTime RegisDate { get; set; }


        [Display(Name = "Cancel Date")]
        [Required(ErrorMessage = "*")]
        public DateTime CancelDate { get; set; }


        [Display(Name = "Fund Status")]
        [Required(ErrorMessage = "*")]
        public string FundStatus { get; set; }


        public int MAmcId { get; set; }


        public string PermitUs { get; set; }


        public int CountryFlag { get; set; }


        [Display(Name = "Active")]
        public bool StatusFlag { get; set; }


        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }


        public virtual MAmc MAmc { get; set; }


        //public List<FundSummary> FundSummarys { get; set; }


        public List<FundTransaction> FundTransactions { get; set; }

        public List<DailyNav> DailyNavs { get; set; }

        public MFund()
        {
            StatusFlag = true;
            LastUpdate = DateTime.Now;
        }
    }
}
