using BusinessLayer.Common;
using IncomePlannerDB.IncomePlannerDbService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncomePlanner.Controllers.Common
{
    [Authorize(Roles = "Admin,User")]
    [Route("Api/Common")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private MasterBusinessLayer masterBusinessLayer;

        public MasterController(IncomePlannerDbContext incomePlannerDbContext)
        {
            masterBusinessLayer = new MasterBusinessLayer(incomePlannerDbContext);
        }

        [HttpGet]
        [Route("Regimes")]
        public List<Regimes> GetRegimes()
        {
            List<Regimes> result = masterBusinessLayer.GetRegimes();

            return result;
        }

        [HttpGet]
        [Route("FinancialYears")]
        public List<Years> GetFinancialYears()
        {
            List<Years> result = masterBusinessLayer.GetFinancialYears();

            return result;
        }
    }
}
