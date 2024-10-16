using BusinessLayer.Expense;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System;
using IncomePlannerDB.IncomePlannerDbService;
using BusinessLayer.Banking;
using Model.Banking;
using DataLayer.Banking;

namespace IncomePlanner.Controllers.Banking
{
    [Route("api/Banking")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private BankingBusinessLayer bankingBusinessLayer;

        public BankingController(IncomePlannerDbContext incomePlannerDbContext)
        {
            bankingBusinessLayer = new BankingBusinessLayer(incomePlannerDbContext);
        }

        #region Get Methods
        [HttpGet]
        [Route("GetBankAccounts")]
        public async Task<IActionResult> GetBankAccounts()
        {
            try
            {
                int userId = 0;
                if (HttpContext.User.Claims.Where(x => x.Type == "Id").Any())
                {
                    userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value);
                }
                var result = await bankingBusinessLayer.GetBankAccounts(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        #endregion

        #region Post Methods
        [HttpPost]
        [Route("PostBankAccounts")]
        public async Task<IActionResult> PostBankAccounts(BankAccountBase bankAccountBase)
        {
            try
            {
                int userId = 0;
                if (HttpContext.User.Claims.Where(x => x.Type == "Id").Any())
                {
                    userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value);
                }
                var result = await bankingBusinessLayer.PostBankAccounts(userId, bankAccountBase);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        #endregion

        #region Delete Methods
        [HttpPost]
        [Route("DeleteBankAccounts")]
        public async Task<IActionResult> DeleteBankAccount(int accountId)
        {
            try
            {
                int userId = 0;
                if (HttpContext.User.Claims.Where(x => x.Type == "Id").Any())
                {
                    userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value);
                }
                var result = await bankingBusinessLayer.DeleteAccount(accountId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        #endregion
    }
}
