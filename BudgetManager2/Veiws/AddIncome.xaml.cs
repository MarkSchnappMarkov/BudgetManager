using BudgetManager2.ViewModels;

namespace BudgetManager2.Veiws;

public partial class AddIncome : ContentPage
{
    public AddIncome(AddIncomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
