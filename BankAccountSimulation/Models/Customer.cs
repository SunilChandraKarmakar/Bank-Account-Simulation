using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide name please.")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide email please.")]
        [StringLength(40, MinimumLength = 10)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Provide password please.")]
        [StringLength(30, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Provide confirm password please.")]
        [StringLength(30, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Does not match in Password!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Provide contact no please.")]
        [StringLength(14, MinimumLength = 11)]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Provide join date please.")]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "Provide branch please.")]
        public int BranchId { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }

        [Required(ErrorMessage = "Provide address please.")]
        [StringLength(500, MinimumLength = 3)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        public Branch Branch { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
