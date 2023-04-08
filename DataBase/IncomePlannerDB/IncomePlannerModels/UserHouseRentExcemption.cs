using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IncomePlannerDB.IncomePlannerModels
{
    public class UserHouseRentExcemption
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("FinancialYears")]
        public int FinancialYear { get; set; }
        [ForeignKey("TaxRegimes")]
        public int TaxRegimeType { get; set; }
        public double TotalRentPaidPerAnnum { get; set; }
        public double DearnessAllowance { get; set; }
        public bool IsMetroCity { get; set; }
        public double ExemptedAmount { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public FinancialYear FinancialYears { get; set; }
        public TaxRegime TaxRegimes { get; set; }
    }
}
