using System;
using SQLite;

namespace BudgetManager2.Model
{
	public class Income
	{
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Amount { get; set; }
    }
}

