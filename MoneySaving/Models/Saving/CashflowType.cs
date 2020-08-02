using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneySaving.Models
{
    public class CashflowType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Required(ErrorMessage = "*")]
        public string Name { get; set; }


        [Display(Name = "Active")]
        public bool StatusFlag { get; set; }

      
        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }

        public virtual IdentityUser User { get; set; }


        public List<MCategory> MCategories { get; set; }


        public CashflowType()
        {
            LastUpdate = DateTime.Now;
            StatusFlag = true;
        }
    }
}
