using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class TransferMoney
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide your account number")]
        public int AccountId { get; set; } 

        [Required(ErrorMessage = "Provide sending account number")]
        [DataType(DataType.PhoneNumber)]
        public string SendAccountNumber { get; set; }

        [Required(ErrorMessage = "Provide ammount")]
        [DataType(DataType.Currency)]
        public float Ammount { get; set; }

        [Required(ErrorMessage = "Provide date")]
        [DataType(DataType.Date)]
        public DateTime TransferMoneyDate { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
