using System;
using BudgetManager2.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace BudgetManager2.ViewModels
{
    public partial class AddExpenseViewModel : ObservableObject
    {
        private readonly Services.IBudgetManagerServices _budgetService;

        Budget UpdatedBudget { get;set; }

        public AddExpenseViewModel(Services.IBudgetManagerServices budgetService)
        {
            _budgetService = budgetService;
        }

        [ObservableProperty]
        private double _amount;

        [ICommand]
        public async void AddExpense()
        {
            var response = await _budgetService.AddExpense(new Model.Expense
            {
                Amount = Amount
            });

            var budgets = await _budgetService.GetBudgetList();
            UpdatedBudget = budgets.First();
            UpdatedBudget.Amount -= _amount;
            await _budgetService.UpdateBudget(UpdatedBudget);

            if (response > 0)
            {
                await Shell.Current.DisplayAlert($"Expense with amount {Amount} Added", "Expense added to table", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Expense Not Added", "Something happened", "OK");
            }
        }
    }
}

