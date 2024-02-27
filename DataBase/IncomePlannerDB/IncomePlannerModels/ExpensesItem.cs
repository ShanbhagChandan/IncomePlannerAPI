using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IncomePlannerDB.IncomePlannerModels
{
    public class ExpensesItem
    {
        public int Id { get; set; }
        [ForeignKey("ExpensesTables")]
        public int TableId { get; set; }
        public string ItemName { get; set; }
        public double BaseCost { get; set; }
        public double AdditionalCost { get; set; }
        public double TotalCost { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ExpensesTable ExpensesTables { get; set; }
    }
}
