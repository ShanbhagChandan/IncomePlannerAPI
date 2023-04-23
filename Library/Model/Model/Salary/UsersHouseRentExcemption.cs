using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Salary
{
    public class UsersHouseRentExcemption
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FinancialYear { get; set; }
        public int TaxRegimeType { get; set; }
        public double TotalRentPaidPerAnnum { get; set; }
        public double DearnessAllowance { get; set; }
        public bool IsMetroCity { get; set; }
        public double ExemptedAmount { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
