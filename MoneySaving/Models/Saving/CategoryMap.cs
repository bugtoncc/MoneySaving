using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoneySaving.Models
{
    public class CategoryMap
    {
        public int ID { get; set; }

        [Display(Name = "Active")]
        public bool StatusFlag { get; set; }

        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }


        //--- reference key ---//
        //[Display(Name = "Category")]
        //public int MCategoryId { get; set; }

        //[Display(Name = "Category")]
        //public MCategory MCategory { get; set; }

        //[Display(Name = "Pocket")]
        //public int MPocketId { get; set; }

        //[Display(Name = "Pocket")]
        //public MPocket MPocket { get; set; }
        //public ICollection<MainTransaction> MainTransactions { get; set; }

        public virtual IdentityUser User { get; set; }

        public CategoryMap()
        {
            LastUpdate = DateTime.Now;
            StatusFlag = true;
        }
    }
}
