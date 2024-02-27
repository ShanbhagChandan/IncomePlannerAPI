using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Charts
{
    public class ExpensesChartsData
    {
        public string ChartItemName { get; set; }
        public List<ExpensesDataSeries> DataSeries { get; set; } = new List<ExpensesDataSeries>();
    }
}
