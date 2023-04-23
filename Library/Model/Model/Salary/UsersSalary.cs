using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Salary
{
    public class UsersSalary
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FinancialYear { get; set; }
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
    }
}
