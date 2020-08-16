using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneySaving.Models
{
    public class DailyNav
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Display(Name = "Fund")]
        public int MFundId { get; set; }


        [Display(Name = "Nav date")]
        [DataType(DataType.Date)]
        public DateTime nav_date { get; set; }


        public double net_asset { get; set; }


        [Display(Name = "NAV")]
        [DisplayFormat(DataFormatString = "{0:n4}", ApplyFormatInEditMode = true)]
        public double last_val { get; set; }


        [Display(Name = "Previous NAV")]
        [DisplayFormat(DataFormatString = "{0:n4}", ApplyFormatInEditMode = true)]
        public double previous_val { get; set; }


        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }


        [Display(Name = "Fund")]
        public virtual MFund MFund { get; set; }
    }

    public class UpdateNavModel
    {
        public SelectList FundSelectListFilter { get; set; }

        public int MFundId { get; set; }
        public string QueryFundKeyword { get; set; }
    }
}
