using DataLayer.Common;
using IncomePlannerDB.IncomePlannerDbService;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Common
{
    public class MasterBusinessLayer
    {
        private MasterDataLayer masterDataLayer;
        public MasterBusinessLayer(IncomePlannerDbContext incomePlannerDbContext)
        {
            masterDataLayer = new MasterDataLayer(incomePlannerDbContext);
        }

        public async Task<List<Regimes>> GetRegimes()
        {
            List<Regimes> result = await masterDataLayer.GetRegimes();

            return result;
        }

        public async Task<List<Years>> GetFinancialYears()
        {
            List<Years> result = await masterDataLayer.GetFinancialYears();

            return result;
        }

        public async Task<List<Banks>> GetBanks()
        {
            List<Banks> result = await masterDataLayer.GetBanks();

            return result;
        }

        public async Task<List<AccountTypes>> GetAccountTypes()
        {
            List<AccountTypes> result = await masterDataLayer.GetAccountTypes();

            return result;
        }
    }
}
