using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class WithdrawMoney
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide your account number")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Please provide withdraw account number")]
        public string WithdrawNumber { get; set; }

        [Required(ErrorMessage = "Please provide withdraw ammount")]
        [DataType(DataType.Currency)]
        public float Ammount { get; set; }

        [Required(ErrorMessage = "Please provide withdraw date time")]
        [DataType(DataType.DateTime)]
        public DateTime WithdrawDate { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
