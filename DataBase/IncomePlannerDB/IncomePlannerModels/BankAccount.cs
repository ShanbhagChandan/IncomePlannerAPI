using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IncomePlannerDB.IncomePlannerModels
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("Banks")]
        public int BankId { get; set; }
        [ForeignKey("AccountTypes")]
        public int AccountTypeId { get; set; }
        public string AccountName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Bank Banks { get; set; }
        public AccountType AccountTypes { get; set; }

        public ICollection<Saving> Saving { get; set; }
        public ICollection<FixedDeposit> FixedDeposit { get; set; }
        public ICollection<RecurringDeposit> RecurringDeposit { get; set; }
        public ICollection<MutualFund> MutualFund { get; set; }

    }
}
