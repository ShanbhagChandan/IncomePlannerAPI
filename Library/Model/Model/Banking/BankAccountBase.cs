using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Banking
{
    public class BankAccountBase
    {
        public int AccountId { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public bool IsNationalisedBank { get; set; }
        public int AccountTypeId { get; set; }
        public string AccountType { get; set; }
        public string AccountName { get; set; }
        public BankSavingDetails BankSavingDetails { get; set; } = null;
        public BankFixedDepositDetails BankFixedDepositDetails { get; set; } = null;
        public BankRecurringDepositDetails BankRecurringDepositDetails { get; set;} = null;
        public List<BankMutualFundsDetails> BankMutualFundsDetails { get; set; } = null;
    }
}
