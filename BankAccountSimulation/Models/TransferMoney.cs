using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class TransferMoney
    {
        public int Id { get; set; }
        public int AccountId { get; set; } 
        public string SendAccountNumber { get; set; }
        public float Ammount { get; set; }
        public DateTime TransferMoneyDate { get; set; }

        public Account Account { get; set; }
    }
}
