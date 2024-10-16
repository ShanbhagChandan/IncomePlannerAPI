using System;
using System.Collections.Generic;
using System.Text;

namespace IncomePlannerDB.IncomePlannerModels
{
    public class AccountType
    {
        public int Id { get; set; }
        public string AccountTypeName { get; set; }

        public ICollection<BankAccount> BankAccount { get; set; }
    }
}
