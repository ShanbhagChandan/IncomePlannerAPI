using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Banking
{
    public class BankFixedDepositDetails
    {
        public int FixedDepositId { get; set; }
        public double FixedDepositAmount { get; set; }
        public double FixedDepositInterestRate { get; set; }
        public DateTime FixedDepositStartingDate { get; set; }
        public int FixedDepositDurationInMonths { get; set; }
    }
}
