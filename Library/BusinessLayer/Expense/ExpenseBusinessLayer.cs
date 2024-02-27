using DataLayer.Expense;
using DataLayer.Salary;
using IncomePlannerDB.IncomePlannerDbService;
using IncomePlannerDB.IncomePlannerModels;
using IncomePlannerDB.Migrations;
using Model.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Expense
{
    public class ExpenseBusinessLayer
    {
        private ExpenseDataLayer expenseDataLayer;
        public ExpenseBusinessLayer(IncomePlannerDbContext incomePlannerDbContext)
        {
            expenseDataLayer = new ExpenseDataLayer(incomePlannerDbContext);
        }

        #region Get Methods
        public async Task<List<ExpensesTables>> GetExpenseTables(int userId)
        {
            return await expenseDataLayer.GetExpenseTables(userId);
        }

        public async Task<List<ExpensesItems>> GetItemsTable(int userId, int tableId)
        {
            return await expenseDataLayer.GetItemsTable(userId, tableId);
        }
        #endregion

        #region Post Methods
        public async Task<int> PostExpenseTable(int userId, ExpensesTables expensesTables)
        {
            bool isUpdate;
            ExpensesTable expensesTable = new ExpensesTable();

            var getResults = await expenseDataLayer.GetExpenseTables(userId);
            ExpensesTables existingExpensesTables = getResults.Where(x => x.Id == expensesTables.Id).FirstOrDefault();

            if (existingExpensesTables != null)
            {
                isUpdate = true;
                expensesTable.Id = existingExpensesTables.Id;
                expensesTable.UserId = existingExpensesTables.UserId;
                expensesTable.TableName = expensesTables.TableName;
                expensesTable.FinancialYear = expensesTables.FinancialYear;

                expensesTable.CreatedBy = existingExpensesTables.CreatedBy;
                expensesTable.CreatedDate = existingExpensesTables.CreatedDate;

                expensesTable.ModifiedBy = userId;
                expensesTable.ModifiedDate = DateTime.UtcNow;
            }
            else
            {
                isUpdate = false;
                expensesTable.UserId = userId;
                expensesTable.TableName = expensesTables.TableName;
                expensesTable.FinancialYear = expensesTables.FinancialYear;

                expensesTable.CreatedBy = userId;
                expensesTable.CreatedDate = DateTime.UtcNow;

                expensesTable.ModifiedBy = userId;
                expensesTable.ModifiedDate = DateTime.UtcNow;
            }

            return await expenseDataLayer.PostExpenseTable(expensesTable, isUpdate);
        }

        public async Task<int> PostItemsTable(int userId, int tableId, ExpensesItems expensesItems)
        {
            bool isUpdate;
            ExpensesItem expensesItem = new ExpensesItem();

            var getResults = await expenseDataLayer.GetItemsTable(userId, tableId);
            ExpensesItems existingExpensesItems = getResults.Where(x => x.Id == expensesItems.Id).FirstOrDefault();

            if (existingExpensesItems != null)
            {
                isUpdate = true;
                expensesItem.Id = existingExpensesItems.Id;
                expensesItem.TableId = existingExpensesItems.TableId;
                expensesItem.ItemName = expensesItems.ItemName;
                expensesItem.BaseCost = expensesItems.BaseCost;
                expensesItem.AdditionalCost = expensesItems.AdditionalCost;
                expensesItem.TotalCost = expensesItems.TotalCost;

                expensesItem.CreatedBy = existingExpensesItems.CreatedBy;
                expensesItem.CreatedDate = existingExpensesItems.CreatedDate;

                expensesItem.ModifiedBy = userId;
                expensesItem.ModifiedDate = DateTime.UtcNow;
            }
            else
            {
                isUpdate = false;
                expensesItem.TableId = tableId;
                expensesItem.ItemName = expensesItems.ItemName;
                expensesItem.BaseCost = expensesItems.BaseCost;
                expensesItem.AdditionalCost = expensesItems.AdditionalCost;
                expensesItem.TotalCost = expensesItems.TotalCost;

                expensesItem.CreatedBy = userId;
                expensesItem.CreatedDate = DateTime.UtcNow;

                expensesItem.ModifiedBy = userId;
                expensesItem.ModifiedDate = DateTime.UtcNow;
            }

            return await expenseDataLayer.PostItemsTable(expensesItem, isUpdate);
        }
        #endregion

        #region Delete Methods
        public async Task<int> DeleteExpenseTable(int tableId)
        {
            return await expenseDataLayer.DeleteExpenseTable(tableId);
        }

        public async Task<int> DeleteItemsTable(int id)
        {
            return await expenseDataLayer.DeleteItemsTable(id);
        }
        #endregion
    }
}
