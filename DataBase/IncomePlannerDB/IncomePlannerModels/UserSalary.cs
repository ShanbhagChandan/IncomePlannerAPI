using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IncomePlannerDB.IncomePlannerModels
{
    public class UserSalary
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("FinancialYears")]
        public int FinancialYear { get; set; }
        [ForeignKey("TaxRegimes")]
        public int TaxRegimeType { get; set; }
        public double BasicPay { get; set; }
        public double HousingRentAllowance { get; set; }
        public double LeaveTravelAllowance { get; set; }
        public double OtherAllowance { get; set; }
        public double Gratuity { get; set; }
        public double EmployerProvidentFund { get; set; }
        public double BonusPay { get; set; }
        public double VariablePay { get; set; }
        public double TotalIncome { get; set; }
        public double TaxableIncome { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public FinancialYear FinancialYears { get; set; }
        public TaxRegime TaxRegimes { get; set; }
    }
}
