using System;
using BudgetManager2.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace BudgetManager2.ViewModels
{
    public partial class AddIncomeViewModel : ObservableObject
    {
        private readonly Services.IBudgetManagerServices _budgetService;

        Budget UpdatedBudget { get; set; }

        public AddIncomeViewModel(Services.IBudgetManagerServices budgetService)
        {
            _budgetService = budgetService;
        }

        [ObservableProperty]
        private double _amount;

        [ICommand]
        public async void AddIncome()
        {
            var response = await _budgetService.AddIncome(new Model.Income
            {
                Amount = Amount
            });

            var budgets = await _budgetService.GetBudgetList();
            UpdatedBudget = budgets.First();
            UpdatedBudget.Amount += _amount;
            await _budgetService.UpdateBudget(UpdatedBudget);

            if (response > 0)
            {
                await Shell.Current.DisplayAlert($"Income with amount {Amount} Added", "Income added to table", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Income Not Added", "Something happened", "OK");
            }
        }
    }
}

