using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class WithdrawMoney
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public float Ammount { get; set; }
        public DateTime WithdrawDate { get; set; }

        public Account Account { get; set; }
    }
}
