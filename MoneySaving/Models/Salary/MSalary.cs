using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneySaving.Models.Salary
{
    public class MSalary
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Display(Name = "Date")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }


        [Display(Name = "Type")]
        [Required(ErrorMessage = "*")]
        public int MSalaryTypeId { get; set; }


        [Display(Name = "Salary")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Salary { get; set; }


        [Display(Name = "Overtime")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Overtime { get; set; }


        [Display(Name = "Incentive")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Incentive { get; set; }


        [Display(Name = "Bonus")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Bonus { get; set; }


        [Display(Name = "Position")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Position { get; set; }


        [Display(Name = "Diligence")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Diligence { get; set; }


        [Display(Name = "Food")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Food { get; set; }


        [Display(Name = "Vehicle")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Vehicle { get; set; }


        [Display(Name = "Leave")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Leave { get; set; }


        [Display(Name = "Award")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Award { get; set; }


        [Display(Name = "Tax")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Tax { get; set; }


        [Display(Name = "SS")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? SS { get; set; }


        [Display(Name = "PVD")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? PVD { get; set; }


        [Display(Name = "Loan")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double? Loan { get; set; }


        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }


        public virtual IdentityUser User { get; set; }


        [Display(Name = "Type")]
        public virtual MSalaryType MSalaryType { get; set; }


        public MSalary()
        {
            Date = DateTime.Now;
            LastUpdate = DateTime.Now;
        }

    }
}
