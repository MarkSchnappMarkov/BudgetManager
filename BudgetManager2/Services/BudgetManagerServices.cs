using System;
using BudgetManager2.Model;
using SQLite;

namespace BudgetManager2.Services
{
    public class BudgetManagerServices : IBudgetManagerServices
    {
        private SQLiteAsyncConnection _dbConnection;

        async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Budget.db3");

                _dbConnection = new SQLiteAsyncConnection(dbPath);

                 await _dbConnection.CreateTableAsync<Budget>();
                 await _dbConnection.CreateTableAsync<Expense>();
                 await _dbConnection.CreateTableAsync<Income>();      
            }
        }

        #region Add
        public Task<int> AddBudget(Budget budget)
        {
            return _dbConnection.InsertAsync(budget);
        }

        public Task<int> AddExpense(Expense expense)
        {
            return _dbConnection.InsertAsync(expense);
        }

        public Task<int> AddIncome(Income income)
        {
            return _dbConnection.InsertAsync(income);
        }
        #endregion

        #region Delete
        public Task<int> DeleteBudget(Budget budget)
        {
            return _dbConnection.DeleteAsync(budget);
        }

        public Task<int> DeleteExpense(Expense expense)
        {
            return _dbConnection.DeleteAsync(expense);
        }

        public Task<int> DeleteIncome(Income income)
        {
            return _dbConnection.DeleteAsync(income);
        }
        #endregion

        #region Update
        public Task<int> UpdateBudget(Budget budget)
        {
            return _dbConnection.UpdateAsync(budget);
        }

        public Task<int> UpdateExpense(Expense expense)
        {
            return _dbConnection.UpdateAsync(expense);
        }

        public Task<int> UpdateIncome(Income income)
        {
            return _dbConnection.UpdateAsync(income);
        }

        #endregion

        #region GetList

        public async Task<List<Budget>> GetBudgetList()
        {
            await SetUpDb();
            return await _dbConnection.Table<Budget>().ToListAsync();
        }

        public async Task<List<Expense>> GetExpenseList()
        {
            await SetUpDb();
            var expenseList = await _dbConnection.Table<Expense>().ToListAsync();
            return expenseList;
        }

        public async Task<List<Income>> GetIncomeList()
        {
            await SetUpDb();
            var incomeList = await _dbConnection.Table<Income>().ToListAsync();
            return incomeList;
        }
        #endregion
    }
}

