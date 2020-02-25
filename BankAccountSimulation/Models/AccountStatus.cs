using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class AccountStatus
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide Status please.")]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
