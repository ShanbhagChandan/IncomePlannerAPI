using BusinessLayer.Expense;
using DataLayer.Banking;
using DataLayer.Expense;
using IncomePlannerDB.IncomePlannerDbService;
using IncomePlannerDB.IncomePlannerModels;
using Microsoft.EntityFrameworkCore;
using Model.Banking;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Banking
{
    public class BankingBusinessLayer
    {
        private BankingDataLayer bankingDataLayer;
        public BankingBusinessLayer(IncomePlannerDbContext incomePlannerDbContext)
        {
            bankingDataLayer = new BankingDataLayer(incomePlannerDbContext);
        }

        #region Get Methods
        public async Task<List<BankAccountBase>> GetBankAccounts(int userId)
        {
            return await bankingDataLayer.GetBankAccounts(userId);
        }
        #endregion region

        #region Post Methods
        public async Task<int> PostBankAccounts(int userId, BankAccountBase bankAccountBase)
        {
            bool isUpdate;
            BankAccount bankAccount = null;
            int accountId = 0;
            List<int> subId = new List<int>();

            bankAccount = await bankingDataLayer.GetBankAccountsBaseDetails(userId, bankAccountBase.AccountId);

            if (bankAccount != null && bankAccount.Id > 0)
            {
                isUpdate = true;
                bankAccount.AccountName = bankAccountBase.AccountName;
                bankAccount.AccountTypeId = bankAccountBase.AccountTypeId;
                bankAccount.BankId = bankAccountBase.BankId;
                bankAccount.ModifiedBy = userId;
                bankAccount.ModifiedDate = DateTime.UtcNow;

                accountId = await bankingDataLayer.PostAccountDetails(bankAccount, isUpdate);

                if ((AccountTypeEnum)bankAccount.AccountTypeId == AccountTypeEnum.SavingsAccount)
                {
                    Saving saving = await bankingDataLayer.GetSavingsDetails(bankAccount.Id);
                    saving.Amount = bankAccountBase.BankSavingDetails.SavingsId;
                    saving.InterestRate = bankAccountBase.BankSavingDetails.SavingsInterestRate;
                    saving.ModifiedBy = userId;
                    saving.ModifiedDate = DateTime.UtcNow;

                    await bankingDataLayer.PostSavingAccount(saving, isUpdate);
                }
                if ((AccountTypeEnum)bankAccount.AccountTypeId == AccountTypeEnum.FixedDepositAccount)
                {
                    FixedDeposit fixedDeposit = await bankingDataLayer.GetFixedDepositDetails(bankAccount.Id);
                    fixedDeposit.Amount = bankAccountBase.BankFixedDepositDetails.FixedDepositAmount;
                    fixedDeposit.InterestRate = bankAccountBase.BankFixedDepositDetails.FixedDepositInterestRate;
                    fixedDeposit.StartingDate = bankAccountBase.BankFixedDepositDetails.FixedDepositStartingDate;
                    fixedDeposit.DurationInMonths = bankAccountBase.BankFixedDepositDetails.FixedDepositDurationInMonths;
                    fixedDeposit.ModifiedBy = userId;
                    fixedDeposit.ModifiedDate = DateTime.UtcNow;

                    await bankingDataLayer.PostFixedDepositAccount(fixedDeposit, isUpdate);
                }
                if ((AccountTypeEnum)bankAccount.AccountTypeId == AccountTypeEnum.RecurringDepositAccount)
                {
                    RecurringDeposit recurringDeposit = await bankingDataLayer.GetRecurringDepositDetails(bankAccount.Id);
                    recurringDeposit.Amount = bankAccountBase.BankRecurringDepositDetails.RecurringDepositAmount;
                    recurringDeposit.InterestRate = bankAccountBase.BankRecurringDepositDetails.RecurringDepositInterestRate;
                    recurringDeposit.StartingDate = bankAccountBase.BankRecurringDepositDetails.RecurringDepositStartingDate;
                    recurringDeposit.DurationInMonths = bankAccountBase.BankRecurringDepositDetails.RecurringDepositDurationInMonths;
                    recurringDeposit.ModifiedBy = userId;
                    recurringDeposit.ModifiedDate = DateTime.UtcNow;

                    await bankingDataLayer.PostRecurringDepositAccount(recurringDeposit, isUpdate);
                }
                if ((AccountTypeEnum)bankAccount.AccountTypeId == AccountTypeEnum.DematAccount)
                {
                    List<MutualFund> mutualFunds = await bankingDataLayer.GetMutualFundsDetails(bankAccount.Id);

                    foreach(var bankMutualFunds in bankAccountBase.BankMutualFundsDetails)
                    {
                        MutualFund mutualFund = mutualFunds.Where(x => x.Id == bankMutualFunds.MutualFundsId).FirstOrDefault();

                        if(mutualFund != null && mutualFund.MutualFundName != null)
                        {
                            mutualFund.Amount = bankMutualFunds.MutualFundsAmount;
                            mutualFund.InterestRate = bankMutualFunds.MutualFundsInterestRate;
                            mutualFund.StartingDate = bankMutualFunds.MutualFundsStartingDate;
                            mutualFund.DurationInMonths = bankMutualFunds.MutualFundsDurationInMonths;
                            mutualFund.MutualFundName = bankMutualFunds.MutualFundName;
                            mutualFund.ModifiedBy = userId;
                            mutualFund.ModifiedDate = DateTime.UtcNow;

                            await bankingDataLayer.PostMutualFundAccount(mutualFund, true);
                        }
                        else
                        {
                            mutualFund.Amount = bankMutualFunds.MutualFundsAmount;
                            mutualFund.InterestRate = bankMutualFunds.MutualFundsInterestRate;
                            mutualFund.StartingDate = bankMutualFunds.MutualFundsStartingDate;
                            mutualFund.DurationInMonths = bankMutualFunds.MutualFundsDurationInMonths;
                            mutualFund.MutualFundName = bankMutualFunds.MutualFundName;
                            mutualFund.CreatedBy = userId;
                            mutualFund.CreatedDate = DateTime.UtcNow;
                            mutualFund.ModifiedBy = userId;
                            mutualFund.ModifiedDate = DateTime.UtcNow;

                            await bankingDataLayer.PostMutualFundAccount(mutualFund, false);
                        }
                        
                    }

                    var toDeleteMutualFunds = mutualFunds.Where(x => !bankAccountBase.BankMutualFundsDetails.Any(y => y.MutualFundsId == x.Id));
                    foreach (var toDeleteMutualFund in toDeleteMutualFunds)
                    {
                        await bankingDataLayer.DeleteMutualFund(toDeleteMutualFund);
                    }
                }
            }
            else
            {
                isUpdate = false;
                bankAccount = new BankAccount();
                bankAccount.UserId = userId;
                bankAccount.AccountName = bankAccountBase.AccountName;
                bankAccount.AccountTypeId = bankAccountBase.AccountTypeId;
                bankAccount.BankId = bankAccountBase.BankId;
                bankAccount.CreatedBy = userId;
                bankAccount.CreatedDate = DateTime.UtcNow;
                bankAccount.ModifiedBy = userId;
                bankAccount.ModifiedDate = DateTime.UtcNow;

                accountId = await bankingDataLayer.PostAccountDetails(bankAccount, isUpdate);

                if ((AccountTypeEnum)bankAccount.AccountTypeId == AccountTypeEnum.SavingsAccount)
                {
                    Saving saving = new Saving();
                    saving.AccountId = accountId;
                    saving.Amount = bankAccountBase.BankSavingDetails.SavingsAmount;
                    saving.InterestRate = bankAccountBase.BankSavingDetails.SavingsInterestRate;
                    saving.CreatedBy = userId;
                    saving.CreatedDate = DateTime.UtcNow;
                    saving.ModifiedBy = userId;
                    saving.ModifiedDate = DateTime.UtcNow;

                    await bankingDataLayer.PostSavingAccount(saving, isUpdate);
                }
                if ((AccountTypeEnum)bankAccount.AccountTypeId == AccountTypeEnum.FixedDepositAccount)
                {
                    FixedDeposit fixedDeposit = new FixedDeposit();
                    fixedDeposit.AccountId = accountId;
                    fixedDeposit.Amount = bankAccountBase.BankFixedDepositDetails.FixedDepositAmount;
                    fixedDeposit.InterestRate = bankAccountBase.BankFixedDepositDetails.FixedDepositInterestRate;
                    fixedDeposit.StartingDate = bankAccountBase.BankFixedDepositDetails.FixedDepositStartingDate;
                    fixedDeposit.DurationInMonths = bankAccountBase.BankFixedDepositDetails.FixedDepositDurationInMonths;
                    fixedDeposit.CreatedBy = userId;
                    fixedDeposit.CreatedDate = DateTime.UtcNow;
                    fixedDeposit.ModifiedBy = userId;
                    fixedDeposit.ModifiedDate = DateTime.UtcNow;

                    await bankingDataLayer.PostFixedDepositAccount(fixedDeposit, isUpdate);
                }
                if ((AccountTypeEnum)bankAccount.AccountTypeId == AccountTypeEnum.RecurringDepositAccount)
                {
                    RecurringDeposit recurringDeposit = new RecurringDeposit();
                    recurringDeposit.AccountId = accountId;
                    recurringDeposit.Amount = bankAccountBase.BankRecurringDepositDetails.RecurringDepositAmount;
                    recurringDeposit.InterestRate = bankAccountBase.BankRecurringDepositDetails.RecurringDepositInterestRate;
                    recurringDeposit.StartingDate = bankAccountBase.BankRecurringDepositDetails.RecurringDepositStartingDate;
                    recurringDeposit.DurationInMonths = bankAccountBase.BankRecurringDepositDetails.RecurringDepositDurationInMonths;
                    recurringDeposit.CreatedBy = userId;
                    recurringDeposit.CreatedDate = DateTime.UtcNow;
                    recurringDeposit.ModifiedBy = userId;
                    recurringDeposit.ModifiedDate = DateTime.UtcNow;

                    await bankingDataLayer.PostRecurringDepositAccount(recurringDeposit, isUpdate);
                }
                if ((AccountTypeEnum)bankAccount.AccountTypeId == AccountTypeEnum.DematAccount)
                {
                    List<MutualFund> mutualFunds = await bankingDataLayer.GetMutualFundsDetails(bankAccount.Id);

                    foreach (var bankMutualFunds in bankAccountBase.BankMutualFundsDetails)
                    {
                        MutualFund mutualFund = new MutualFund();

                        mutualFund.AccountId = accountId;
                        mutualFund.Amount = bankAccountBase.BankMutualFundsDetails.FirstOrDefault().MutualFundsAmount;
                        mutualFund.InterestRate = bankAccountBase.BankMutualFundsDetails.FirstOrDefault().MutualFundsInterestRate;
                        mutualFund.StartingDate = bankAccountBase.BankMutualFundsDetails.FirstOrDefault().MutualFundsStartingDate;
                        mutualFund.DurationInMonths = bankAccountBase.BankMutualFundsDetails.FirstOrDefault().MutualFundsDurationInMonths;
                        mutualFund.MutualFundName = bankAccountBase.BankMutualFundsDetails.FirstOrDefault().MutualFundName;
                        mutualFund.CreatedBy = userId;
                        mutualFund.CreatedDate = DateTime.UtcNow;
                        mutualFund.ModifiedBy = userId;
                        mutualFund.ModifiedDate = DateTime.UtcNow;

                        await bankingDataLayer.PostMutualFundAccount(mutualFund, isUpdate);
                    }
                }
            }

            return accountId;
        }
        #endregion

        #region Delete Methods
        public async Task<int> DeleteAccount(int accountId)
        {
            return await bankingDataLayer.DeleteAccount(accountId);
        }
        #endregion
    }
}
