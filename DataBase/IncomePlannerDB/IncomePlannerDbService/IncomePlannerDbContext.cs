using IncomePlannerDB.IncomePlannerModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomePlannerDB.IncomePlannerDbService
{
    public class IncomePlannerDbContext : DbContext
    {
        public IncomePlannerDbContext(DbContextOptions<IncomePlannerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxRegime>()
              .HasData(
               new TaxRegime { Id = 1, RegimeType = "Old Tax Regime" , IsDefault = false },
               new TaxRegime { Id = 2 , RegimeType = "New Tax Regime" , IsDefault = true});

            modelBuilder.Entity<FinancialYear>()
              .HasData(
               new FinancialYear { Id = 1, Year = "2018-2019", IsDefault = false },
               new FinancialYear { Id = 2, Year = "2019-2020", IsDefault = false },
               new FinancialYear { Id = 3, Year = "2020-2021", IsDefault = false },
               new FinancialYear { Id = 4, Year = "2021-2022", IsDefault = false },
               new FinancialYear { Id = 5, Year = "2022-2023", IsDefault = false },
               new FinancialYear { Id = 6, Year = "2023-2024", IsDefault = true });

            modelBuilder.Entity<Bank>()
              .HasData(
               new Bank { Id = 1, BankName = "State Bank of India", IsNationalisedBank = true },
               new Bank { Id = 2, BankName = "Canara Bank", IsNationalisedBank = true },
               new Bank { Id = 3, BankName = "Union Bank of India", IsNationalisedBank = true },
               new Bank { Id = 4, BankName = "HDFC Bank", IsNationalisedBank = true },
               new Bank { Id = 5, BankName = "ICICI Bank", IsNationalisedBank = true },
               new Bank { Id = 6, BankName = "Axis Bank", IsNationalisedBank = true },
               new Bank { Id = 7, BankName = "Kotak Mahindra Bank", IsNationalisedBank = true });

            modelBuilder.Entity<AccountType>()
              .HasData(
               new AccountType { Id = 1, AccountTypeName = "Savings Account"},
               new AccountType { Id = 2, AccountTypeName = "Fixed Deposit Account"},
               new AccountType { Id = 3, AccountTypeName = "Recurring Deposit Account" },
               new AccountType { Id = 4, AccountTypeName = "Demat Account"});
        }

        public DbSet<TaxRegime> TaxRegimes { get; set; }
        public DbSet<FinancialYear> FinancialYears { get; set; }
        public DbSet<UserSalary> UserSalarys { get; set; }
        public DbSet<UserHouseRentExcemption> UserHouseRentExcemptions { get; set; }
        public DbSet<ChapterVIASection80CC> ChapterVIASection80CC { get; set; }
        public DbSet<ChapterVIAOtherSection> ChapterVIAOtherSections { get; set; }
        public DbSet<ExpensesItem> ExpensesItems { get; set; }
        public DbSet<ExpensesTable> ExpensesTables { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Saving> Savings { get; set; }
        public DbSet<FixedDeposit> FixedDeposits { get; set; }
        public DbSet<RecurringDeposit> RecurringDeposits { get; set; }
        public DbSet<MutualFund> MutualFunds { get; set; }
    }
}
