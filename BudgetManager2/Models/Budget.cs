using System;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite;

namespace BudgetManager2.Model
{
    public class Budget
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Amount { get; set; }
    }
}

