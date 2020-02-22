using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide name please.")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide user name please.")]
        [StringLength(10, MinimumLength = 5)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Provide email please.")]
        [StringLength(40, MinimumLength = 10)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Provide contact no please.")]
        [StringLength(14, MinimumLength = 11)]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Provide password please.")]
        [StringLength(40, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Provide confirm password please.")]
        [StringLength(40, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password does not match!")]
        public string ConfirmPassword { get; set; }
    }
}
