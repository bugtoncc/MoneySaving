using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneySaving.Models
{
    public class MAmc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Display(Name = "Name TH")]
        [Required(ErrorMessage = "*")]
        public string NameTh { get; set; }


        [Display(Name = "Name EN")]
        [Required(ErrorMessage = "*")]
        public string NameEn { get; set; }

        [Display(Name = "Unique Id")]
        [Required(ErrorMessage = "*")]
        public string UniqueId { get; set; }


        [Display(Name = "Active")]
        public bool StatusFlag { get; set; }


        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }


        public List<MFund> MFunds { get; set; }


        public MAmc()
        {
            StatusFlag = true;
            LastUpdate = DateTime.Now;
        }
    }
}
