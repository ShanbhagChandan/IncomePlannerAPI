using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Charts
{
    public class ExpensesCharts
    {
        public string ChartTitle { get; set; }
        public string ChartSubTitle { get; set; }
        public List<ExpensesChartsData> ExpensesChartsData { get; set; } =  new List<ExpensesChartsData>();
    }
}
