using System;
using System.Collections.Generic;
using System.Text;

namespace IncomePlannerDB.IncomePlannerModels
{
    public class Bank
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public bool IsNationalisedBank { get; set; }

        public ICollection<BankAccount> BankAccount { get; set; }
    }
}
