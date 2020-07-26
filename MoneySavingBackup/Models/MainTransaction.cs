using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace MoneySaving.Models
{
    public class MainTransaction
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }

        //--- reference key ---//
        [Display(Name = "Pocket")]
        public int MpocketId { get; set; }

        [Display(Name = "Pocket")]
        public MPocket MPocket { get; set; }

        [Display(Name = "Category")]
        public int MCategoryId { get; set; }

        [Display(Name = "Category")]
        public MCategory MCategory { get; set; }
        //--- reference key ---//

        [Required(ErrorMessage = "*")]
        public string Detail { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Display(Name = "Active")]
        public bool StatusFlag { get; set; }

        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }

        [Display(Name = "Update By")]
        public string UpdateBy { get; set; }

        //--- reference key ---//
        //[Display(Name = "Category")]
        //public int CategoryMapId { get; set; }

        //[Display(Name = "Category")]
        //public CategoryMap CategoryMap { get; set; }

        public MainTransaction()
        {
            LastUpdate = DateTime.Now;
            UpdateBy = "ADMIN";
            StatusFlag = true;

            TransactionDate = DateTime.Now;
        }
    }
}
