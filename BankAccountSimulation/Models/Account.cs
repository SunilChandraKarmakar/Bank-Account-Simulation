using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide branch name.")]
        public int BranchId { get; set; }

        [Required(ErrorMessage = "Provide customer name.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Provide account number")]
        [StringLength(8, MinimumLength = 8)]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Provide account type.")]
        public int AccountTypeId { get; set; }

        [Required(ErrorMessage = "Initial blance please.")]
        [DataType(DataType.Currency)]
        public float Balance { get; set; }

        [Required(ErrorMessage = "Provide account status.")]
        public int AccountStatusId { get; set; }

        public Branch Branch { get; set; }
        public Customer Customer { get; set; }
        public AccountType AccountType { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public ICollection<TransferMoney> TransferMoney { get; set; }
    }
}
