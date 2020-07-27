using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneySaving.Models
{
    public class MainTransaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Display(Name = "Date")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }


        [Display(Name = "Pocket")]
        public int MpocketId { get; set; }               


        [Display(Name = "Category")]
        public int MCategoryId { get; set; }              


        [Required(ErrorMessage = "*")]
        public string Detail { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }


        [Display(Name = "Active")]
        public bool StatusFlag { get; set; }


        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }


        public virtual IdentityUser User { get; set; }

        [Display(Name = "Pocket")]
        public virtual MPocket MPocket { get; set; }

        [Display(Name = "Category")]
        public virtual MCategory MCategory { get; set; }


        //[Display(Name = "Category")]
        //public int CategoryMapId { get; set; }


        //[Display(Name = "Category")]
        //public CategoryMap CategoryMap { get; set; }


        public MainTransaction()
        {
            LastUpdate = DateTime.Now;
            StatusFlag = true;
            TransactionDate = DateTime.Now;
        }
    }
}
