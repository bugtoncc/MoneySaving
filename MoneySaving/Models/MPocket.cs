using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoneySaving.Models
{
    public class MPocket
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [Display(Name = "Active")]
        public bool StatusFlag { get; set; }

        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }

        [Display(Name = "Update By")]
        public string UpdateBy { get; set; }


        //--- reference key ---//
        public List<CategoryMap> CategoryMaps { get; set; }

        public MPocket()
        {
            LastUpdate = DateTime.Now;
            UpdateBy = "ADMIN";
            StatusFlag = true;
        }
    }
}
