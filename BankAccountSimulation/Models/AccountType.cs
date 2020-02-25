using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class AccountType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide account type please")]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
