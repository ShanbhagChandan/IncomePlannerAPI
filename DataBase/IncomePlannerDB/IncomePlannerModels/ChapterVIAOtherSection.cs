using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IncomePlannerDB.IncomePlannerModels
{
    public class ChapterVIAOtherSection
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("FinancialYears")]
        public int FinancialYear { get; set; }
        [ForeignKey("TaxRegimes")]
        public int TaxRegimeType { get; set; }
        public double NationalPensionScheme { get; set; }
        public double Mediclaim { get; set; }
        public double DisabledDependent { get; set; }
        public double  MedicalExpenses { get; set; }
        public double EducationLoanInterest { get; set; }
        public double HousingLoanInterest { get; set; }
        public double Donations { get; set; }
        public double DepositInterest { get; set; }
        public double TotalInvestments { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public FinancialYear FinancialYears { get; set; }
        public TaxRegime TaxRegimes { get; set; }
    }
}
