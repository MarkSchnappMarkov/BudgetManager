using System;
using System.Collections.ObjectModel;
using BudgetManager2.Services;
using BudgetManager2.Veiws;
using BudgetManager2.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace BudgetManager2.ViewModels
{
    public partial class BudgetManagerMainPageViewModel : ObservableObject
    {
        public ObservableCollection<Budget> Budgets { get; set; } = new ObservableCollection<Budget>();
        public ObservableCollection<Expense> Expenses { get; set; } = new ObservableCollection<Expense>();
        public ObservableCollection<Income> Incomes { get; set; } = new ObservableCollection<Income>();
        public ObservableCollection<Budget> MainBudget { get; set; } = new ObservableCollection<Budget>();

        private readonly IBudgetManagerServices _budgetService;

        public BudgetManagerMainPageViewModel(IBudgetManagerServices budgetService)
        {
            _budgetService = budgetService;
        }

        [ICommand]
        public async void GetBudgetList()
        {
            var budgetList = await _budgetService.GetBudgetList();

            if (budgetList?.Count > 0)
            {
                Budgets.Clear();
                foreach (var budget in budgetList)
                {
                    Budgets.Add(budget);
                }
            }
        }

        [ICommand]
        public async void SetBudget()
        {
            var budgets = await _budgetService.GetBudgetList();

            MainBudget.Add(budgets.First());
        }

        [ICommand]
        public async void GetExpensesList()
        {
            var expensesList = await _budgetService.GetExpenseList();

            if (expensesList?.Count > 0)
            {
                Expenses.Clear();
                foreach (var expense in expensesList)
                {
                    Expenses.Add(expense);
                }
            }
        }

        [ICommand]
        public async void GetIncomesList()
        {
            var incomesList = await _budgetService.GetIncomeList();

            if (incomesList?.Count > 0)
            {
                Incomes.Clear();
                foreach (var income in incomesList)
                {
                    Incomes.Add(income);
                }
            }
        }

        [ICommand]
        public async void GoToAddExpense()
        {
            await AppShell.Current.GoToAsync(nameof(AddExpense));
        }

        [ICommand]
        public async void GoToAddIncome()
        {
            await AppShell.Current.GoToAsync(nameof(AddIncome));
        }
    }
}

