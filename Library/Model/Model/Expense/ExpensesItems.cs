using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Expense
{
    public class ExpensesItems
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public string ItemName { get; set; }
        public double BaseCost { get; set; }
        public double AdditionalCost { get; set; }
        public double TotalCost { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
