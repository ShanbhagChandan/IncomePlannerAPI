using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Salary
{
    public class ChapterVIAOtherSections
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FinancialYear { get; set; }
        public int TaxRegimeType { get; set; }
        public double NationalPensionScheme { get; set; }
        public double Mediclaim { get; set; }
        public double DisabledDependent { get; set; }
        public double MedicalExpenses { get; set; }
        public double EducationLoanInterest { get; set; }
        public double HousingLoanInterest { get; set; }
        public double Donations { get; set; }
        public double DepositInterest { get; set; }
        public double TotalInvestments { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
