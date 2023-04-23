using IncomePlannerDB.IncomePlannerDbService;
using IncomePlannerDB.IncomePlannerModels;
using Microsoft.EntityFrameworkCore;
using Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Salary
{
    public class SalaryDataLayer
    {
        private IncomePlannerDbContext _dbContext;

        public SalaryDataLayer(IncomePlannerDbContext incomePlannerDbContext)
        {
            _dbContext = incomePlannerDbContext;
        }

        #region Get Methods
        public UsersSalary GetSalary(int userId, int year)
        {
            UsersSalary userSalary = _dbContext.UserSalarys.Where(x => x.UserId == userId && x.FinancialYear == year)
                .Select(x => new UsersSalary
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FinancialYear = x.FinancialYear,
                    TaxRegimeType = x.TaxRegimeType,
                    BasicPay = x.BasicPay,
                    HousingRentAllowance = x.HousingRentAllowance,
                    LeaveTravelAllowance = x.LeaveTravelAllowance,
                    OtherAllowance = x.OtherAllowance,
                    Gratuity = x.Gratuity,
                    EmployerProvidentFund = x.EmployerProvidentFund,
                    BonusPay = x.BonusPay,
                    VariablePay = x.VariablePay,
                    TotalIncome = x.TotalIncome,
                    TaxableIncome = x.TaxableIncome,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate
                }).FirstOrDefault();

            return userSalary;
        }

        public UsersHouseRentExcemption GetHRAInvestments(int userId, int year)
        {
            UsersHouseRentExcemption usersHouseRentExcemption = _dbContext.UserHouseRentExcemptions.Where(x => x.UserId == userId && x.FinancialYear == year)
                .Select(x => new UsersHouseRentExcemption
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FinancialYear = x.FinancialYear,
                    TaxRegimeType = x.TaxRegimeType,
                    TotalRentPaidPerAnnum = x.TotalRentPaidPerAnnum,
                    DearnessAllowance = x.DearnessAllowance,
                    IsMetroCity = x.IsMetroCity,
                    ExemptedAmount = x.ExemptedAmount,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate
                }).FirstOrDefault();

            return usersHouseRentExcemption;
        }

        public ChapterVIASections80CC Get80CCInvestment(int userId, int year)
        {
            ChapterVIASections80CC chapterVIASections80CC = _dbContext.ChapterVIASection80CC.Where(x => x.UserId == userId && x.FinancialYear == year)
                .Select(x => new ChapterVIASections80CC
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FinancialYear = x.FinancialYear,
                    TaxRegimeType = x.TaxRegimeType,
                    EmployeesProvidentFund = x.EmployeesProvidentFund,
                    PublicProvidentFund = x.PublicProvidentFund,
                    NationalSavingsCertificate = x.NationalSavingsCertificate,
                    LifeInsurancePremium = x.LifeInsurancePremium,
                    MutualFunds = x.MutualFunds,
                    TutionFee = x.TutionFee,
                    HomeLoanRepay = x.HomeLoanRepay,
                    Others = x.Others,
                    TotalInvestments = x.TotalInvestments,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate
                }).FirstOrDefault();

            return chapterVIASections80CC;
        }

        public ChapterVIAOtherSections GetOtherSection(int userId, int year)
        {
            ChapterVIAOtherSections chapterVIAOtherSections = _dbContext.ChapterVIAOtherSections.Where(x => x.UserId == userId && x.FinancialYear == year)
                .Select(x => new ChapterVIAOtherSections
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FinancialYear = x.FinancialYear,
                    TaxRegimeType = x.TaxRegimeType,
                    NationalPensionScheme = x.NationalPensionScheme,
                    Mediclaim = x.Mediclaim,
                    DisabledDependent = x.DisabledDependent,
                    MedicalExpenses = x.MedicalExpenses,
                    EducationLoanInterest = x.EducationLoanInterest,
                    HousingLoanInterest = x.HousingLoanInterest,
                    Donations = x.Donations,
                    DepositInterest = x.DepositInterest,
                    TotalInvestments = x.TotalInvestments,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate
                }).FirstOrDefault();

            return chapterVIAOtherSections;
        }
        #endregion

        #region Post Methods
        public int PostSalary(UserSalary usersSalary, bool isUpdate)
        {
            if (isUpdate)
            {
                _dbContext.Entry(usersSalary).State = EntityState.Modified;
            }
            else
            {
                _dbContext.UserSalarys.Add(usersSalary);
            }

            _dbContext.SaveChanges();

            return 1;
        }

        public int PostHRAInvestment(UserHouseRentExcemption userHouseRentExcemption, bool isUpdate)
        {
            if (isUpdate)
            {
                _dbContext.Entry(userHouseRentExcemption).State = EntityState.Modified;
            }
            else
            {
                _dbContext.UserHouseRentExcemptions.Add(userHouseRentExcemption);
            }

            _dbContext.SaveChanges();

            return 1;
        }

        public int Post80CCInvestment(ChapterVIASection80CC chapterVIASection80CC, bool isUpdate)
        {
            if (isUpdate)
            {
                _dbContext.Entry(chapterVIASection80CC).State = EntityState.Modified;
            }
            else
            {
                _dbContext.ChapterVIASection80CC.Add(chapterVIASection80CC);
            }

            _dbContext.SaveChanges();

            return 1;
        }

        public int PostOtherSection(ChapterVIAOtherSection chapterVIAOtherSection, bool isUpdate)
        {
            if (isUpdate)
            {
                _dbContext.Entry(chapterVIAOtherSection).State = EntityState.Modified;
            }
            else
            {
                _dbContext.ChapterVIAOtherSections.Add(chapterVIAOtherSection);
            }

            _dbContext.SaveChanges();

            return 1;
        }
        #endregion

        #region Delete Methods
        public int DeleteSalary(UsersSalary usersSalary)
        {
            _dbContext.Entry(usersSalary).State = EntityState.Deleted;
            _dbContext.SaveChanges();

            return 1;
        }

        public int DeleteHRAInvestment(UsersHouseRentExcemption userHouseRentExcemption)
        {
            _dbContext.Entry(userHouseRentExcemption).State = EntityState.Deleted;
            _dbContext.SaveChanges();

            return 1;
        }

        public int Delete80CCInvestment(ChapterVIASections80CC chapterVIASection80CC)
        {
            _dbContext.Entry(chapterVIASection80CC).State = EntityState.Deleted;
            _dbContext.SaveChanges();

            return 1;
        }

        public int DeletetOtherSection(ChapterVIAOtherSections chapterVIAOtherSection)
        {
            _dbContext.Entry(chapterVIAOtherSection).State = EntityState.Deleted;
            _dbContext.SaveChanges();

            return 1;
        }
        #endregion region
    }
}
