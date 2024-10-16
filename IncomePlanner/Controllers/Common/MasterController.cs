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
        public async Task<IActionResult> GetRegimes()
        {
            try
            {
                List<Regimes> result = await masterBusinessLayer.GetRegimes();

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
            
        }

        [HttpGet]
        [Route("FinancialYears")]
        public async Task<IActionResult> GetFinancialYears()
        {
            try
            {
                List<Years> result = await masterBusinessLayer.GetFinancialYears();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        [Route("Banks")]
        public async Task<IActionResult> GetBanks()
        {
            try
            {
                List<Banks> result = await masterBusinessLayer.GetBanks();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }            
        }

        [HttpGet]
        [Route("AccountTypes")]
        public async Task<IActionResult> GetAccountTypes()
        {
            try
            {
                List<AccountTypes> result = await masterBusinessLayer.GetAccountTypes();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }           
        }
    }
}
