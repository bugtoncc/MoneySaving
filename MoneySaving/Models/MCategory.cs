﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoneySaving.Models
{

    public class MCategory
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
        [Display(Name = "Cashflow Type")]
        public int CashflowTypeId { get; set; }

        [Display(Name = "Cashflow Type")]
        public CashflowType CashflowType { get; set; }
        //public List<CategoryMap> CategoryMaps { get; set; }
        public List<MainTransaction> MainTransactions { get; set; }


        public MCategory()
        {
            LastUpdate = DateTime.Now;
            UpdateBy = "ADMIN";
            StatusFlag = true;
        }
    }
}
