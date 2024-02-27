using BusinessLayer.Expense;
using BusinessLayer.Salary;
using DataLayer.Expense;
using IncomePlannerDB.IncomePlannerDbService;
using IncomePlannerDB.IncomePlannerModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Common;
using Model.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncomePlanner.Controllers.Expense
{
    [Route("Api/Expense")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private ExpenseBusinessLayer expenseBusinessLayer;

        public ExpenseController(IncomePlannerDbContext incomePlannerDbContext)
        {
            expenseBusinessLayer = new ExpenseBusinessLayer(incomePlannerDbContext);
        }

        #region Get Methods
        [HttpGet]
        [Route("GetExpenseTable")]
        public async Task<IActionResult> GetExpenseTables()
        {
            try
            {
                int userId = 0;
                if (HttpContext.User.Claims.Where(x => x.Type == "Id").Any())
                {
                    userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value);
                }
                var result = await expenseBusinessLayer.GetExpenseTables(userId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            } 
        }

        [HttpGet]
        [Route("GetItemsTable")]
        public async Task<IActionResult> GetItemsTable(int tableId)
        {
            try
            {
                int userId = 0;
                if (HttpContext.User.Claims.Where(x => x.Type == "Id").Any())
                {
                    userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value);
                }
                var result = await expenseBusinessLayer.GetItemsTable(userId, tableId);
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
        [Route("PostExpenseTable")]
        public async Task<IActionResult> PostExpenseTable(ExpensesTables expensesTables)
        {
            try
            {
                int userId = 0;
                if (HttpContext.User.Claims.Where(x => x.Type == "Id").Any())
                {
                    userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value);
                }

                var result = await expenseBusinessLayer.PostExpenseTable(userId, expensesTables);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [Route("PostItemsTable")]
        public async Task<IActionResult> PostItemsTable(int tableId,ExpensesItems expensesItems)
        {
            try
            {
                int userId = 0;
                if (HttpContext.User.Claims.Where(x => x.Type == "Id").Any())
                {
                    userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value);
                }
                var result = await expenseBusinessLayer.PostItemsTable(userId, tableId, expensesItems);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500,"Internal Server Error");
            }
        }
        #endregion

        #region Delete Methods
        [HttpPost]
        [Route("DeleteExpenseTable")]
        public async Task<IActionResult> DeleteExpenseTable(int tableId)
        {
            try
            {
                int userId = 0;
                if (HttpContext.User.Claims.Where(x => x.Type == "Id").Any())
                {
                    userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value);
                }
                var result = await expenseBusinessLayer.DeleteExpenseTable(tableId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }     
        }

        [HttpPost]
        [Route("DeleteItemsTable")]
        public async Task<IActionResult> DeleteItemsTable(int id)
        {
            try
            {
                int userId = 0;
                if (HttpContext.User.Claims.Where(x => x.Type == "Id").Any())
                {
                    userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value);
                }
                var result = await expenseBusinessLayer.DeleteItemsTable(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        #endregion
    }
}
