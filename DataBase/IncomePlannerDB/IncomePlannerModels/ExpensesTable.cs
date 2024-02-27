using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IncomePlannerDB.IncomePlannerModels
{
    public class ExpensesTable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TableName { get; set; }
        [ForeignKey("FinancialYears")]
        public int FinancialYear { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<ExpensesItem> ExpensesItem { get; set; }
        public FinancialYear FinancialYears { get; set; }
    }
}
