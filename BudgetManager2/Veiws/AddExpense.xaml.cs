using BudgetManager2.ViewModels;

namespace BudgetManager2.Veiws;

public partial class AddExpense : ContentPage
{
    public AddExpense(AddExpenseViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; 
    }
}
