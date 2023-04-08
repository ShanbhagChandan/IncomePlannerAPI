using DataLayer.Common;
using IncomePlannerDB.IncomePlannerDbService;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Common
{
    public class MasterBusinessLayer
    {
        private MasterDataLayer masterDataLayer;
        public MasterBusinessLayer(IncomePlannerDbContext incomePlannerDbContext)
        {
            masterDataLayer = new MasterDataLayer(incomePlannerDbContext);
        }

        public List<Regimes> GetRegimes()
        {
            List<Regimes> result = masterDataLayer.GetRegimes();

            return result;
        }

        public List<Years> GetFinancialYears()
        {
            List<Years> result = masterDataLayer.GetFinancialYears();

            return result;
        }

    }
}
