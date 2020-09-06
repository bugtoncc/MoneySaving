using MoneySaving.Models.Salary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneySaving.Models
{
    public class MSalaryType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }


        [Display(Name = "Active")]
        public bool StatusFlag { get; set; }


        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }


        public List<MSalary> MSalaries { get; set; }


        public MSalaryType()
        {
            StatusFlag = true;
            LastUpdate = DateTime.Now;
        }
    }
}
