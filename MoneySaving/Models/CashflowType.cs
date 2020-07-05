using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneySaving.Models
{
    public class CashflowType
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [Display(Name = "Active")]
        public bool StatusFlag { get; set; }

        [Display(Name = "Last Update")]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdate { get; set; }

        [Display(Name= "Update By")]
        public string UpdateBy { get; set; }


        //--- reference key ---//
        public List<MCategory> MCategories { get; set; }

        public CashflowType()
        {
            LastUpdate = DateTime.Now;
            UpdateBy = "ADMIN";
        }
    }
}
