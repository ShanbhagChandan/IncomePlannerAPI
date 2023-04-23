﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Salary
{
    public class ChapterVIASections80CC
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FinancialYear { get; set; }
        public int TaxRegimeType { get; set; }
        public double EmployeesProvidentFund { get; set; }
        public double PublicProvidentFund { get; set; }
        public double NationalSavingsCertificate { get; set; }
        public double LifeInsurancePremium { get; set; }
        public double MutualFunds { get; set; }
        public double TutionFee { get; set; }
        public double HomeLoanRepay { get; set; }
        public double Others { get; set; }
        public double TotalInvestments { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
