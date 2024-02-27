using IncomePlannerDB.IncomePlannerDbService;
using IncomePlannerDB.IncomePlannerModels;
using IncomePlannerDB.Migrations;
using Microsoft.EntityFrameworkCore;
using Model.Expense;
using Model.Salary;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataLayer.Expense
{
    public class ExpenseDataLayer
    {
        private IncomePlannerDbContext _dbContext;

        public ExpenseDataLayer(IncomePlannerDbContext incomePlannerDbContext)
        {
            _dbContext = incomePlannerDbContext;
        }

        #region Get Methods
        public async Task<List<ExpensesTables>> GetExpenseTables(int userId)
        {
            List<ExpensesTables> expensesTables = await _dbContext.ExpensesTables.Where(x => x.UserId == userId)
                .Select(x => new ExpensesTables
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    TableName = x.TableName,
                    FinancialYear = x.FinancialYear,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate
                }).ToListAsync();

            return expensesTables;
        }

        public async Task<List<ExpensesItems>> GetItemsTable(int userId, int tableId)
        {
            List<ExpensesItems> expensesItems = await _dbContext.ExpensesItems.Where(x => x.TableId == tableId)
                .Select(x => new ExpensesItems
                {
                    Id = x.Id,
                    TableId = x.TableId,
                    ItemName = x.ItemName,
                    BaseCost = x.BaseCost,
                    AdditionalCost = x.AdditionalCost,
                    TotalCost = x.TotalCost,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate
                }).ToListAsync();

            return expensesItems;
        }
        #endregion

        #region Post Methods
        public async Task<int> PostExpenseTable(ExpensesTable expensesTables, bool isUpdate)
        {
            if (isUpdate)
            {
                _dbContext.Entry(expensesTables).State = EntityState.Modified;
            }
            else
            {
                _dbContext.ExpensesTables.Add(expensesTables);
            }

            await _dbContext.SaveChangesAsync();

            return expensesTables.Id;
        }

        public async Task<int> PostItemsTable(ExpensesItem expensesItems, bool isUpdate)
        {
            if (isUpdate)
            {
                _dbContext.Entry(expensesItems).State = EntityState.Modified;
            }
            else
            {
                _dbContext.ExpensesItems.Add(expensesItems);
            }

            await _dbContext.SaveChangesAsync();

            return expensesItems.Id;
        }
        #endregion

        #region Delete Methods
        public async Task<int> DeleteExpenseTable(int tableId)
        {
            ExpensesTable expensesTable = await _dbContext.ExpensesTables.Where(x => x.Id == tableId).FirstOrDefaultAsync();

            _dbContext.ExpensesTables.Remove(expensesTable);

            _dbContext.SaveChanges();

            return expensesTable.Id;
        }

        public async Task<int> DeleteItemsTable(int id)
        {
            ExpensesItem expensesItem = await _dbContext.ExpensesItems.Where(x => x.Id == id).FirstOrDefaultAsync();

            _dbContext.ExpensesItems.Remove(expensesItem);

            _dbContext.SaveChanges();

            return expensesItem.Id;
        }
        #endregion
    }
}
