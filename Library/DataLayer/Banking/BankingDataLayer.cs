using IncomePlannerDB.IncomePlannerDbService;
using IncomePlannerDB.IncomePlannerModels;
using Microsoft.EntityFrameworkCore;
using Model.Banking;
using Model.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataLayer.Banking
{
    public class BankingDataLayer
    {
        private IncomePlannerDbContext _dbContext;

        public BankingDataLayer(IncomePlannerDbContext incomePlannerDbContext)
        {
            _dbContext = incomePlannerDbContext;
        }

        #region Get Methods
        public async Task<List<BankAccountBase>> GetBankAccounts(int userId)
        {
            List<BankAccountBase> bankAccountBases = await _dbContext.BankAccounts.Where(x => x.UserId == userId)
                .Include(x=>x.Banks).Include(x => x.AccountTypes).Include(x => x.Saving)
                .Include(x => x.FixedDeposit).Include(x => x.RecurringDeposit).Include(x => x.MutualFund)
                .Select(x => new BankAccountBase
                {
                    AccountId = x.Id,
                    BankId = x.BankId,
                    BankName = x.Banks.BankName,
                    IsNationalisedBank = x.Banks.IsNationalisedBank,
                    AccountTypeId = x.AccountTypeId,
                    AccountType = x.AccountTypes.AccountTypeName,
                    AccountName = x.AccountName,
                    BankSavingDetails = x.Saving.Select(y => new BankSavingDetails()
                    {
                        SavingsId = y.Id,
                        SavingsAmount = y.Amount,
                        SavingsInterestRate = y.InterestRate
                    }).FirstOrDefault(),
                    BankFixedDepositDetails = x.FixedDeposit.Select(y => new BankFixedDepositDetails()
                    {
                        FixedDepositId = y.Id,
                        FixedDepositAmount = y.Amount,
                        FixedDepositInterestRate = y.InterestRate,
                        FixedDepositStartingDate = y.StartingDate,
                        FixedDepositDurationInMonths = y.DurationInMonths
                    }).FirstOrDefault(),
                    BankRecurringDepositDetails = x.RecurringDeposit.Select(y => new BankRecurringDepositDetails()
                    {
                        RecurringDepositId = y.Id,
                        RecurringDepositAmount = y.Amount,
                        RecurringDepositInterestRate = y.InterestRate,
                        RecurringDepositStartingDate = y.StartingDate,
                        RecurringDepositDurationInMonths = y.DurationInMonths
                    }).FirstOrDefault(),
                    BankMutualFundsDetails = x.MutualFund.Select(y => new BankMutualFundsDetails()
                    {
                        MutualFundsId = y.Id,
                        MutualFundsAmount = y.Amount,
                        MutualFundsInterestRate = y.InterestRate,
                        MutualFundsStartingDate = y.StartingDate,
                        MutualFundsDurationInMonths = y.DurationInMonths,
                        MutualFundName = y.MutualFundName,
                    }).ToList()
                }).ToListAsync();

            return bankAccountBases;
        }

        public async Task<BankAccount> GetBankAccountsBaseDetails(int userId,int accountId)
        {
            BankAccount bankAccount = await _dbContext.BankAccounts.AsNoTracking()
                .Where(x => x.UserId == userId && x.Id == accountId).FirstOrDefaultAsync();

            return bankAccount;
        }

        public async Task<Saving> GetSavingsDetails(int accountId)
        {
            Saving saving = await _dbContext.Savings.AsNoTracking()
                .Where(x => x.AccountId == accountId).FirstOrDefaultAsync();

            return saving;
        }

        public async Task<FixedDeposit> GetFixedDepositDetails(int accountId)
        {
            FixedDeposit fixedDeposit = await _dbContext.FixedDeposits.AsNoTracking()
                .Where(x => x.AccountId == accountId).FirstOrDefaultAsync();

            return fixedDeposit;
        }

        public async Task<RecurringDeposit> GetRecurringDepositDetails(int accountId)
        {
            RecurringDeposit recurringDeposit = await _dbContext.RecurringDeposits.AsNoTracking()
                .Where(x => x.AccountId == accountId).FirstOrDefaultAsync();

            return recurringDeposit;
        }

        public async Task<List<MutualFund>> GetMutualFundsDetails(int accountId)
        {
            List<MutualFund> mutualFund = await _dbContext.MutualFunds.AsNoTracking()
                .Where(x => x.AccountId == accountId).ToListAsync();

            return mutualFund;
        }
        #endregion

        #region Post Methods
        public async Task<int> PostAccountDetails(BankAccount bankAccount, bool isUpdate)
        {
            if (isUpdate)
            {
                _dbContext.Entry(bankAccount).State = EntityState.Modified;
            }
            else
            {
                _dbContext.BankAccounts.Add(bankAccount);
            }

            await _dbContext.SaveChangesAsync();

            return bankAccount.Id;
        }

        public async Task<int> PostSavingAccount(Saving saving, bool isUpdate)
        {
            try
            {
                if (isUpdate)
                {
                    _dbContext.Entry(saving).State = EntityState.Modified;
                }
                else
                {
                    _dbContext.Savings.Add(saving);
                }

                await _dbContext.SaveChangesAsync();

                return saving.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> PostFixedDepositAccount(FixedDeposit fixedDeposit, bool isUpdate)
        {
            if (isUpdate)
            {
                _dbContext.Entry(fixedDeposit).State = EntityState.Modified;
            }
            else
            {
                _dbContext.FixedDeposits.Add(fixedDeposit);
            }

            await _dbContext.SaveChangesAsync();

            return fixedDeposit.Id;
        }

        public async Task<int> PostRecurringDepositAccount(RecurringDeposit recurringDeposit, bool isUpdate)
        {
            if (isUpdate)
            {
                _dbContext.Entry(recurringDeposit).State = EntityState.Modified;
            }
            else
            {
                _dbContext.RecurringDeposits.Add(recurringDeposit);
            }

            await _dbContext.SaveChangesAsync();

            return recurringDeposit.Id;
        }

        public async Task<int> PostMutualFundAccount(MutualFund mutualFund, bool isUpdate)
        {
            if (isUpdate)
            {
                _dbContext.Entry(mutualFund).State = EntityState.Modified;
            }
            else
            {
                _dbContext.MutualFunds.Add(mutualFund);
            }

            await _dbContext.SaveChangesAsync();

            return mutualFund.Id;
        }
        #endregion

        #region Delete Methods
        public async Task<int> DeleteAccount(int accountId)
        {
            BankAccount bankAccount = await _dbContext.BankAccounts.Where(x => x.Id == accountId).FirstOrDefaultAsync();

            _dbContext.BankAccounts.Remove(bankAccount);

            await _dbContext.SaveChangesAsync();

            return bankAccount.Id;
        }

        public async Task<int> DeleteMutualFund(MutualFund mutualFund)
        {
            _dbContext.MutualFunds.Remove(mutualFund);

            await _dbContext.SaveChangesAsync();

            return mutualFund.Id;
        }
        #endregion
    }
}
