using System;
using BudgetManager2.Model;
namespace BudgetManager2.Services
{
    public interface IBudgetManagerServices
    {
        Task<List<Budget>> GetBudgetList();
        Task<int> AddBudget(Budget budget);
        Task<int> DeleteBudget(Budget budget);
        Task<int> UpdateBudget(Budget budget);

        Task<List<Expense>> GetExpenseList();
        Task<int> AddExpense(Expense expense);
        Task<int> DeleteExpense(Expense expense);
        Task<int> UpdateExpense(Expense expense);

        Task<List<Income>> GetIncomeList();
        Task<int> AddIncome(Income income);
        Task<int> DeleteIncome(Income income);
        Task<int> UpdateIncome(Income income);
    }
}

