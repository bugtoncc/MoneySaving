using System;
using System.ComponentModel.DataAnnotations;

namespace MoneySaving.Models
{
    public class TransferMoney
    {
        [Display(Name = "Date")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Source")]
        public int PocketFromId { get; set; }


        [Display(Name = "Destination")]
        public int PocketToId { get; set; }


        [Display(Name = "Amount")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }
    }
}
