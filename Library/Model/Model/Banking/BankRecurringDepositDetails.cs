using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Banking
{
    public class BankRecurringDepositDetails
    {
        public int RecurringDepositId { get; set; }
        public double RecurringDepositAmount { get; set; }
        public double RecurringDepositInterestRate { get; set; }
        public DateTime RecurringDepositStartingDate { get; set; }
        public int RecurringDepositDurationInMonths { get; set; }
    }
}
