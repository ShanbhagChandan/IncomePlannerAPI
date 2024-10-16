using DataLayer.Charts;
using DataLayer.Common;
using DataLayer.Expense;
using IncomePlannerDB.IncomePlannerDbService;
using Model.Charts;
using Model.Common;
using Model.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Charts
{
    public class ChartsBusinessLayer
    {
        private ChartsDataLayer expenseDataLayer;
        private MasterDataLayer masterDataLayer;
        public ChartsBusinessLayer(IncomePlannerDbContext incomePlannerDbContext)
        {
            expenseDataLayer = new ChartsDataLayer(incomePlannerDbContext);
            masterDataLayer = new MasterDataLayer(incomePlannerDbContext);
        }

        #region Get Methods
        public async Task<List<ExpensesCharts>> GetExpenseCharts(int userId)
        {
            List<ExpensesCharts> expensesCharts = new List<ExpensesCharts>();
            List<ExpensesTables> expensesTables = await expenseDataLayer.GetExpenseCharts(userId);
            List<Years> years = await masterDataLayer.GetFinancialYears();

            if (expensesTables != null & expensesTables.Count > 0)
            {
                foreach (var expenseTable in expensesTables)
                {
                    ExpensesCharts expensesChart = new ExpensesCharts();
                    List<ExpensesChartsData> expensesChartsDatas = new List<ExpensesChartsData>();

                    expensesChart.ChartTitle = expenseTable.TableName;
                    expensesChart.ChartSubTitle = years.Where(x => x.Id == expenseTable.FinancialYear).Select(x => x.Year).FirstOrDefault();

                    if (expenseTable.ExpensesItems != null & expenseTable.ExpensesItems.Count > 0)
                    {
                        foreach (var expenseItem in expenseTable.ExpensesItems)
                        {
                            ExpensesChartsData expensesChartsData = new ExpensesChartsData();
                            expensesChartsData.ChartItemName = expenseItem.ItemName;
                            
                            ExpensesDataSeries baseCostDataSeries = new ExpensesDataSeries();
                            baseCostDataSeries.Name = "Base Cost";
                            baseCostDataSeries.Value = expenseItem.BaseCost;
                            expensesChartsData.DataSeries.Add(baseCostDataSeries);

                            ExpensesDataSeries additionalCostDataSeries = new ExpensesDataSeries();
                            additionalCostDataSeries.Name = "Additional Cost";
                            additionalCostDataSeries.Value = expenseItem.AdditionalCost;
                            expensesChartsData.DataSeries.Add(additionalCostDataSeries);

                            ExpensesDataSeries totalCostDataSeries = new ExpensesDataSeries();
                            totalCostDataSeries.Name = "Total Cost";
                            totalCostDataSeries.Value = expenseItem.TotalCost;
                            expensesChartsData.DataSeries.Add(totalCostDataSeries);

                            expensesChartsDatas.Add(expensesChartsData);
                        }
                    }

                    expensesChart.ExpensesChartsData = expensesChartsDatas;

                    expensesCharts.Add(expensesChart);
                }
            }
            return expensesCharts;
        }
        #endregion
    }
}
