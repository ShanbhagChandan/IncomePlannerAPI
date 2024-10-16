using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Banking
{
    public class BankMutualFundsDetails
    {
        public int MutualFundsId { get; set; }
        public double MutualFundsAmount { get; set; }
        public double MutualFundsInterestRate { get; set; }
        public DateTime MutualFundsStartingDate { get; set; }
        public int MutualFundsDurationInMonths { get; set; }
        public string MutualFundName { get; set; }
    }
}
