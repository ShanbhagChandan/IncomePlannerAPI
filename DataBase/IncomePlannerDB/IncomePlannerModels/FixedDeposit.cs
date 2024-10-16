using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IncomePlannerDB.IncomePlannerModels
{
    public class FixedDeposit
    {
        public int Id { get; set; }
        [ForeignKey("BankAccounts")]
        public int AccountId { get; set; }
        public double Amount { get; set; }
        public double InterestRate { get; set; }
        public DateTime StartingDate { get; set; }
        public int DurationInMonths { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public BankAccount BankAccounts { get; set; }
    }
}
