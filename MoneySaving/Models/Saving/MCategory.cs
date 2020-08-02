using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneySaving.Models
{

    public class MCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Required(ErrorMessage = "*")]
        public string Name { get; set; }


        [Display(Name = "Cashflow Type")]
        public int CashflowTypeId { get; set; }


        [Display(Name = "Active")]
        public bool StatusFlag { get; set; }


        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }


        public virtual IdentityUser User { get; set; }

        [Display(Name = "Cashflow Type")]
        public virtual CashflowType CashflowType { get; set; }


        public List<MainTransaction> MainTransactions { get; set; }
        //public List<CategoryMap> CategoryMaps { get; set; }


        public MCategory()
        {
            LastUpdate = DateTime.Now;
            StatusFlag = true;
        }
    }
}
