using IncomePlannerDB.IncomePlannerDbService;
using Microsoft.EntityFrameworkCore;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Common
{
    public class MasterDataLayer
    {
        private IncomePlannerDbContext _dbContext;

        public MasterDataLayer(IncomePlannerDbContext incomePlannerDbContext)
        {
            _dbContext = incomePlannerDbContext;
        }

        public async Task<List<Regimes>> GetRegimes()
        {
            List<Regimes> result = await _dbContext.TaxRegimes.Select(x => new Regimes()
            {
                Id = x.Id,
                RegimeType = x.RegimeType,
                IsDefault = x.IsDefault
            }).ToListAsync();

            return result;
        }

        public async Task<List<Years>> GetFinancialYears()
        {
            List<Years> result = await _dbContext.FinancialYears.Select(x => new Years()
            {
                Id = x.Id,
                Year = x.Year,
                IsDefault = x.IsDefault
            }).ToListAsync();

            return result;
        }

        public async Task<List<Banks>> GetBanks()
        {
            List<Banks> result = await _dbContext.Banks.Select(x => new Banks()
            {
                Id = x.Id,
                BankName = x.BankName,
                IsNationalisedBank = x.IsNationalisedBank
            }).ToListAsync();

            return result;
        }

        public async Task<List<AccountTypes>> GetAccountTypes()
        {
            List<AccountTypes> result = await _dbContext.AccountTypes.Select(x => new AccountTypes()
            {
                Id = x.Id,
                AccountTypeName = x.AccountTypeName
            }).ToListAsync();

            return result;
        }
    }
}
