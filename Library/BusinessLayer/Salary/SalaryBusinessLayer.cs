using DataLayer.Salary;
using IncomePlannerDB.IncomePlannerDbService;
using IncomePlannerDB.IncomePlannerModels;
using Model.Salary;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Salary
{
    public class SalaryBusinessLayer
    {
        private SalaryDataLayer salaryDataLayer;
        public SalaryBusinessLayer(IncomePlannerDbContext incomePlannerDbContext)
        {
            salaryDataLayer = new SalaryDataLayer(incomePlannerDbContext);
        }

        public UsersSalary GetSalary(int userId, int year)
        {
            return salaryDataLayer.GetSalary(userId, year);
        }

        public UsersInvestments GetInvestments(int userId, int year)
        {
            UsersHouseRentExcemption usersHouseRentExcemption = salaryDataLayer.GetHRAInvestments(userId, year);
            ChapterVIASections80CC chapterVIASections80CC = salaryDataLayer.Get80CCInvestment(userId, year);
            ChapterVIAOtherSections chapterVIAOtherSections = salaryDataLayer.GetOtherSection(userId, year);

            UsersInvestments usersInvestments = new UsersInvestments
            {
                UsersHouseRentExcemption = usersHouseRentExcemption,
                ChapterVIASections80CC = chapterVIASections80CC,
                ChapterVIAOtherSections = chapterVIAOtherSections
            };

            return usersInvestments;
        }

        public int PostSalary(int userId, UsersSalary usersSalary)
        {
            bool isUpdate;
            UserSalary userSalary = new UserSalary();
            UserHouseRentExcemption hraDetails = new UserHouseRentExcemption();
            ChapterVIASection80CC details80CC = new ChapterVIASection80CC();
            ChapterVIAOtherSection detailsOtherSections = new ChapterVIAOtherSection();

            UsersSalary existsingSalary = salaryDataLayer.GetSalary(userId, usersSalary.FinancialYear);

            //update
            if (existsingSalary != null && usersSalary.TaxRegimeType == existsingSalary.TaxRegimeType)
            {
                userSalary.Id = existsingSalary.Id;
                userSalary.UserId = existsingSalary.UserId;

                userSalary.CreatedBy = existsingSalary.CreatedBy;
                userSalary.CreatedDate = existsingSalary.CreatedDate;
                userSalary.ModifiedBy = userId;
                userSalary.ModifiedDate = DateTime.UtcNow;

                isUpdate = true;
            }
            //insert
            else
            {
                userSalary.UserId = userId;
                userSalary.CreatedBy = userId;
                userSalary.CreatedDate = DateTime.UtcNow;
                userSalary.ModifiedBy = userId;
                userSalary.ModifiedDate = DateTime.UtcNow;

                if (usersSalary.TaxRegimeType == 1)
                {
                    //for old regime add all the values as 0
                    //hra table update with bydefault 0 values
                    hraDetails.UserId = userId;
                    hraDetails.FinancialYear = usersSalary.FinancialYear;
                    hraDetails.TaxRegimeType = usersSalary.TaxRegimeType;
                    hraDetails.TotalRentPaidPerAnnum = 0;
                    hraDetails.DearnessAllowance = 0;
                    hraDetails.IsMetroCity = false;
                    hraDetails.ExemptedAmount = 0;
                    hraDetails.CreatedBy = userId;
                    hraDetails.CreatedDate = DateTime.UtcNow;
                    hraDetails.ModifiedBy = userId;
                    hraDetails.ModifiedDate = DateTime.UtcNow;

                    int response1 = salaryDataLayer.PostHRAInvestment(hraDetails, false);

                    //80CC table update with bydefault 0 values
                    details80CC.UserId = userId;
                    details80CC.FinancialYear = usersSalary.FinancialYear;
                    details80CC.TaxRegimeType = usersSalary.TaxRegimeType;
                    details80CC.EmployeesProvidentFund = 0;
                    details80CC.PublicProvidentFund = 0;
                    details80CC.NationalSavingsCertificate = 0;
                    details80CC.LifeInsurancePremium = 0;
                    details80CC.MutualFunds = 0;
                    details80CC.TutionFee = 0;
                    details80CC.HomeLoanRepay = 0;
                    details80CC.Others = 0;
                    details80CC.TotalInvestments = 0;
                    details80CC.CreatedBy = userId;
                    details80CC.CreatedDate = DateTime.UtcNow;
                    details80CC.ModifiedBy = userId;
                    details80CC.ModifiedDate = DateTime.UtcNow;

                    int response2 = salaryDataLayer.Post80CCInvestment(details80CC, false);

                    //Other Setions table update with by default 0 Values
                    detailsOtherSections.UserId = userId;
                    detailsOtherSections.FinancialYear = usersSalary.FinancialYear;
                    detailsOtherSections.TaxRegimeType = usersSalary.TaxRegimeType;
                    detailsOtherSections.NationalPensionScheme = 0;
                    detailsOtherSections.Mediclaim = 0;
                    detailsOtherSections.DisabledDependent = 0;
                    detailsOtherSections.MedicalExpenses = 0;
                    detailsOtherSections.EducationLoanInterest = 0;
                    detailsOtherSections.HousingLoanInterest = 0;
                    detailsOtherSections.Donations = 0;
                    detailsOtherSections.DepositInterest = 0;
                    detailsOtherSections.TotalInvestments = 0;
                    detailsOtherSections.CreatedBy = userId;
                    detailsOtherSections.CreatedDate = DateTime.UtcNow;
                    detailsOtherSections.ModifiedBy = userId;
                    detailsOtherSections.ModifiedDate = DateTime.UtcNow;

                    int response3 = salaryDataLayer.PostOtherSection(detailsOtherSections, false);
                }
                else if (usersSalary.TaxRegimeType == 2)
                {
                    //for new regime remove the existing investments
                    UsersHouseRentExcemption userHouseRentExcemption = new UsersHouseRentExcemption();
                    userHouseRentExcemption = salaryDataLayer.GetHRAInvestments(userId, usersSalary.FinancialYear);
                    if (userHouseRentExcemption != null)
                    {
                        int response1 = salaryDataLayer.DeleteHRAInvestment(userHouseRentExcemption);
                    }
                    
                    ChapterVIASections80CC chapterVIASection80CC = new ChapterVIASections80CC();
                    chapterVIASection80CC = salaryDataLayer.Get80CCInvestment(userId, usersSalary.FinancialYear);
                    if (chapterVIASection80CC != null)
                    {
                        int response2 = salaryDataLayer.Delete80CCInvestment(chapterVIASection80CC);
                    }
                    
                    ChapterVIAOtherSections chapterVIAOtherSection = new ChapterVIAOtherSections();
                    chapterVIAOtherSection = salaryDataLayer.GetOtherSection(userId, usersSalary.FinancialYear);
                    if (chapterVIAOtherSection!=null)
                    {
                        int response3 = salaryDataLayer.DeletetOtherSection(chapterVIAOtherSection);
                    }
                }

                isUpdate = false;
            }

            //update common properties to model
            userSalary.FinancialYear = usersSalary.FinancialYear;
            userSalary.TaxRegimeType = usersSalary.TaxRegimeType;
            userSalary.BasicPay = usersSalary.BasicPay;
            userSalary.HousingRentAllowance = usersSalary.HousingRentAllowance;
            userSalary.LeaveTravelAllowance = usersSalary.LeaveTravelAllowance;
            userSalary.OtherAllowance = usersSalary.OtherAllowance;
            userSalary.Gratuity = usersSalary.Gratuity;
            userSalary.EmployerProvidentFund = usersSalary.EmployerProvidentFund;
            userSalary.BonusPay = usersSalary.BonusPay;
            userSalary.VariablePay = usersSalary.VariablePay;
            userSalary.TotalIncome = usersSalary.TotalIncome;
            userSalary.TaxableIncome = usersSalary.TaxableIncome;

            salaryDataLayer.PostSalary(userSalary, isUpdate);

            return 1;
        }

        public int PostInvestments(int userId, UsersInvestments usersInvestments)
        {
            bool isUpdateHouseRentExcemption;
            bool isUpdateChapterVIASections80CC;
            bool isUpdateChapterVIAOtherSection;

            UserHouseRentExcemption userHouseRentExcemption = new UserHouseRentExcemption();
            ChapterVIASection80CC chapterVIASection80CC = new ChapterVIASection80CC();
            ChapterVIAOtherSection chapterVIAOtherSection = new ChapterVIAOtherSection();

            UsersHouseRentExcemption existsingHouseRentExcemption = salaryDataLayer.GetHRAInvestments(userId, usersInvestments.UsersHouseRentExcemption.FinancialYear);
            ChapterVIASections80CC existsingChapterVIASections80CC = salaryDataLayer.Get80CCInvestment(userId, usersInvestments.ChapterVIASections80CC.FinancialYear);
            ChapterVIAOtherSections existsingChapterVIAOtherSection = salaryDataLayer.GetOtherSection(userId, usersInvestments.ChapterVIAOtherSections.FinancialYear);

            //house rent allowance update or insert
            if(existsingHouseRentExcemption!=null && usersInvestments.UsersHouseRentExcemption.TaxRegimeType == existsingHouseRentExcemption.TaxRegimeType)
            {
                userHouseRentExcemption.Id = existsingHouseRentExcemption.Id;
                userHouseRentExcemption.UserId = existsingHouseRentExcemption.UserId;

                userHouseRentExcemption.CreatedBy = existsingHouseRentExcemption.CreatedBy;
                userHouseRentExcemption.CreatedDate = existsingHouseRentExcemption.CreatedDate;
                userHouseRentExcemption.ModifiedBy = userId;
                userHouseRentExcemption.ModifiedDate = DateTime.UtcNow;

                isUpdateHouseRentExcemption = true;
            }
            else
            {
                userHouseRentExcemption.UserId = userId;
                userHouseRentExcemption.CreatedBy = userId;
                userHouseRentExcemption.CreatedDate = DateTime.UtcNow;
                userHouseRentExcemption.ModifiedBy = userId;
                userHouseRentExcemption.ModifiedDate = DateTime.UtcNow;

                isUpdateHouseRentExcemption = false;
            }

            userHouseRentExcemption.FinancialYear = usersInvestments.UsersHouseRentExcemption.FinancialYear;
            userHouseRentExcemption.TaxRegimeType = usersInvestments.UsersHouseRentExcemption.TaxRegimeType;
            userHouseRentExcemption.TotalRentPaidPerAnnum = usersInvestments.UsersHouseRentExcemption.TotalRentPaidPerAnnum;
            userHouseRentExcemption.DearnessAllowance = usersInvestments.UsersHouseRentExcemption.DearnessAllowance;
            userHouseRentExcemption.IsMetroCity = usersInvestments.UsersHouseRentExcemption.IsMetroCity;
            userHouseRentExcemption.ExemptedAmount = usersInvestments.UsersHouseRentExcemption.ExemptedAmount;

            int response1 = salaryDataLayer.PostHRAInvestment(userHouseRentExcemption, isUpdateHouseRentExcemption);

            //chapter VI A Section 80 CC update or insert
            if (existsingChapterVIASections80CC != null && usersInvestments.ChapterVIASections80CC.TaxRegimeType == existsingChapterVIASections80CC.TaxRegimeType)
            {
                chapterVIASection80CC.Id = existsingChapterVIASections80CC.Id;
                chapterVIASection80CC.UserId = existsingChapterVIASections80CC.UserId;

                chapterVIASection80CC.CreatedBy = existsingChapterVIASections80CC.CreatedBy;
                chapterVIASection80CC.CreatedDate = existsingChapterVIASections80CC.CreatedDate;
                chapterVIASection80CC.ModifiedBy = userId;
                chapterVIASection80CC.ModifiedDate = DateTime.UtcNow;

                isUpdateChapterVIASections80CC = true;
            }
            else
            {
                chapterVIASection80CC.UserId = userId;
                chapterVIASection80CC.CreatedBy = userId;
                chapterVIASection80CC.CreatedDate = DateTime.UtcNow;
                chapterVIASection80CC.ModifiedBy = userId;
                chapterVIASection80CC.ModifiedDate = DateTime.UtcNow;

                isUpdateChapterVIASections80CC = false;
            }

            chapterVIASection80CC.FinancialYear = usersInvestments.ChapterVIASections80CC.FinancialYear;
            chapterVIASection80CC.TaxRegimeType = usersInvestments.ChapterVIASections80CC.TaxRegimeType;
            chapterVIASection80CC.EmployeesProvidentFund = usersInvestments.ChapterVIASections80CC.EmployeesProvidentFund;
            chapterVIASection80CC.PublicProvidentFund = usersInvestments.ChapterVIASections80CC.PublicProvidentFund;
            chapterVIASection80CC.NationalSavingsCertificate = usersInvestments.ChapterVIASections80CC.NationalSavingsCertificate;
            chapterVIASection80CC.LifeInsurancePremium = usersInvestments.ChapterVIASections80CC.LifeInsurancePremium;
            chapterVIASection80CC.MutualFunds = usersInvestments.ChapterVIASections80CC.MutualFunds;
            chapterVIASection80CC.TutionFee = usersInvestments.ChapterVIASections80CC.TutionFee;
            chapterVIASection80CC.HomeLoanRepay = usersInvestments.ChapterVIASections80CC.HomeLoanRepay;
            chapterVIASection80CC.Others = usersInvestments.ChapterVIASections80CC.Others;
            chapterVIASection80CC.TotalInvestments = usersInvestments.ChapterVIASections80CC.TotalInvestments;

            int response2 = salaryDataLayer.Post80CCInvestment(chapterVIASection80CC, isUpdateChapterVIASections80CC);

            //chapter VI A Other Sections update or insert
            if (existsingChapterVIAOtherSection != null && usersInvestments.ChapterVIAOtherSections.TaxRegimeType == existsingChapterVIAOtherSection.TaxRegimeType)
            {
                chapterVIAOtherSection.Id = existsingChapterVIASections80CC.Id;
                chapterVIAOtherSection.UserId = existsingChapterVIASections80CC.UserId;

                chapterVIAOtherSection.CreatedBy = existsingChapterVIASections80CC.CreatedBy;
                chapterVIAOtherSection.CreatedDate = existsingChapterVIASections80CC.CreatedDate;
                chapterVIAOtherSection.ModifiedBy = userId;
                chapterVIAOtherSection.ModifiedDate = DateTime.UtcNow;

                isUpdateChapterVIAOtherSection = true;
            }
            else
            {
                chapterVIAOtherSection.UserId = userId;
                chapterVIAOtherSection.CreatedBy = userId;
                chapterVIAOtherSection.CreatedDate = DateTime.UtcNow;
                chapterVIAOtherSection.ModifiedBy = userId;
                chapterVIAOtherSection.ModifiedDate = DateTime.UtcNow;

                isUpdateChapterVIAOtherSection = false;
            }

            chapterVIAOtherSection.FinancialYear = usersInvestments.ChapterVIAOtherSections.FinancialYear;
            chapterVIAOtherSection.TaxRegimeType = usersInvestments.ChapterVIAOtherSections.TaxRegimeType;
            chapterVIAOtherSection.NationalPensionScheme = usersInvestments.ChapterVIAOtherSections.NationalPensionScheme;
            chapterVIAOtherSection.Mediclaim = usersInvestments.ChapterVIAOtherSections.Mediclaim;
            chapterVIAOtherSection.DisabledDependent = usersInvestments.ChapterVIAOtherSections.DisabledDependent;
            chapterVIAOtherSection.MedicalExpenses = usersInvestments.ChapterVIAOtherSections.MedicalExpenses;
            chapterVIAOtherSection.EducationLoanInterest = usersInvestments.ChapterVIAOtherSections.EducationLoanInterest;
            chapterVIAOtherSection.HousingLoanInterest = usersInvestments.ChapterVIAOtherSections.HousingLoanInterest;
            chapterVIAOtherSection.Donations = usersInvestments.ChapterVIAOtherSections.Donations;
            chapterVIAOtherSection.DepositInterest = usersInvestments.ChapterVIAOtherSections.DepositInterest;
            chapterVIAOtherSection.TotalInvestments = usersInvestments.ChapterVIAOtherSections.TotalInvestments;

            int response3 = salaryDataLayer.PostOtherSection(chapterVIAOtherSection, isUpdateChapterVIAOtherSection);

            return 1;
        }
    }
}
