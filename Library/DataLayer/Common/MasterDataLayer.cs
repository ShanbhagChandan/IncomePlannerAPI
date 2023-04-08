using IncomePlannerDB.IncomePlannerDbService;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Common
{
    public class MasterDataLayer
    {
        private IncomePlannerDbContext _dbContext;

        public MasterDataLayer(IncomePlannerDbContext incomePlannerDbContext)
        {
            _dbContext = incomePlannerDbContext;
        }

        public List<Regimes> GetRegimes()
        {
            List<Regimes> result = _dbContext.TaxRegimes.Select(x => new Regimes()
            {
                Id = x.Id,
                RegimeType = x.RegimeType,
                IsDefault = x.IsDefault
            }).ToList();

            return result;
        }

        public List<Years> GetFinancialYears()
        {
            List<Years> result = _dbContext.FinancialYears.Select(x => new Years()
            {
                Id = x.Id,
                Year = x.Year,
                IsDefault = x.IsDefault
            }).ToList();

            return result;
        }
    }
}
