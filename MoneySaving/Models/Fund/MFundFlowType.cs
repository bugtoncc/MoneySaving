using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneySaving.Models
{
    public class MFundFlowType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Required(ErrorMessage = "*")]
        public string Name { get; set; }


        [Display(Name = "Active")]
        public bool StatusFlag { get; set; }


        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }


        public List<FundTransaction> FundTransactions { get; set; }


        public MFundFlowType()
        {
            StatusFlag = true;
            LastUpdate = DateTime.Now;
        }
    }
}
