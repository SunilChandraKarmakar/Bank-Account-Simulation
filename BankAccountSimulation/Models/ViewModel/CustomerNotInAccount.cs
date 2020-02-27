using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModel
{
    public class CustomerNotInAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
        public DateTime JoinDate { get; set; }
        public int BranchId { get; set; }
        public string Picture { get; set; }
        public string Address { get; set; }
    }
}
