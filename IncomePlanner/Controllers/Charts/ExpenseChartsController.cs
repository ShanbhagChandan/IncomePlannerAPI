using BusinessLayer.Expense;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System;
using IncomePlannerDB.IncomePlannerDbService;
using BusinessLayer.Charts;

namespace IncomePlanner.Controllers.Charts
{
    [Route("api/ExpenseCharts")]
    [ApiController]
    public class ExpenseChartsController : ControllerBase
    {
        private ChartsBusinessLayer chartsBusinessLayer;

        public ExpenseChartsController(IncomePlannerDbContext incomePlannerDbContext)
        {
            chartsBusinessLayer = new ChartsBusinessLayer(incomePlannerDbContext);
        }

        #region Get Methods
        [HttpGet]
        [Route("GetExpenseCharts")]
        public async Task<IActionResult> GetExpenseCharts()
        {
            try
            {
                int userId = 0;
                if (HttpContext.User.Claims.Where(x => x.Type == "Id").Any())
                {
                    userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value);
                }
                var result = await chartsBusinessLayer.GetExpenseCharts(userId);
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
