using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneySaving.Models
{
    public class FundSummary
    {

        public int FundPortId { get; private set; }
        public int MFundId { get; private set; }
        public int MFundFlowTypeId { get; private set; }

        public virtual string UserId { get; private set; }


        [Display(Name = "Unit")]
        [DisplayFormat(DataFormatString = "{0:n4}", ApplyFormatInEditMode = true)]
        public double unit { get; private set; }


        [Display(Name = "Avg Nav")]
        [DisplayFormat(DataFormatString = "{0:n4}", ApplyFormatInEditMode = true)]
        public double avg_price { get; private set; }


        [Display(Name = "Cost")]
        [DataType(DataType.Currency)]
        public double cost { get; private set; }


        [Display(Name = "Nav date")]
        [DataType(DataType.Date)]
        public DateTime nav_date { get; private set; }


        [Display(Name = "Nav")]
        public double nav_price { get; private set; }


        [Display(Name = "Nav previous")]
        public double nav_prev { get; private set; }


        [Display(Name = "Current")]
        [DataType(DataType.Currency)]
        public double current_value { get; private set; }


        [Display(Name = "Gain")]
        [DataType(DataType.Currency)]
        public double gain_baht { get; private set; }


        [Display(Name = "Gain percent")]
        public double gain_per { get; private set; }


        [Display(Name = "Type")]
        public virtual MFundFlowType MFundFlowType { get; set; }


        [Display(Name = "Fund")]
        public virtual MFund MFund { get; set; }


        [Display(Name = "Port")]
        public virtual FundPort FundPort { get; set; }
    }
}
