using IncomePlannerDB.IncomePlannerDbService;
using Microsoft.EntityFrameworkCore;
using Model.Charts;
using Model.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomePlannerDB.IncomePlannerModels;

namespace DataLayer.Charts
{
    public class ChartsDataLayer
    {
        private IncomePlannerDbContext _dbContext;

        public ChartsDataLayer(IncomePlannerDbContext incomePlannerDbContext)
        {
            _dbContext = incomePlannerDbContext;
        }

        #region Get Methods
        public async Task<List<ExpensesTables>> GetExpenseCharts(int userId)
        {
            List<ExpensesTables> expensesTables = await _dbContext.ExpensesTables.Where(x => x.UserId == userId).Include(x => x.ExpensesItem).Select(x => new ExpensesTables()
            {
                Id = x.Id,
                UserId = x.UserId,
                TableName = x.TableName,
                FinancialYear = x.FinancialYear,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                ExpensesItems = x.ExpensesItem.Select(y => new ExpensesItems()
                {
                    Id = y.Id,
                    TableId = y.TableId,
                    ItemName = y.ItemName,
                    BaseCost = y.BaseCost,
                    AdditionalCost = y.AdditionalCost,
                    TotalCost = y.TotalCost,
                    CreatedBy = y.CreatedBy,
                    CreatedDate = y.CreatedDate,
                    ModifiedBy = y.ModifiedBy,
                    ModifiedDate = y.ModifiedDate
                }).OrderBy(x=>x.ItemName).ToList()
            }).ToListAsync();

            return expensesTables;
        }
        #endregion
    }
}
