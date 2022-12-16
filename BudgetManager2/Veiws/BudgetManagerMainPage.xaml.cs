using BudgetManager2.ViewModels;

namespace BudgetManager2.Veiws;

public partial class BudgetManagerMainPage : ContentPage
{
    private BudgetManagerMainPageViewModel _viewModel;

    public BudgetManagerMainPage(BudgetManagerMainPageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetBudgetListCommand.Execute(null);
        _viewModel.SetBudgetCommand.Execute(null);
        _viewModel.GetExpensesListCommand.Execute(null); 
        _viewModel.GetIncomesListCommand.Execute(null);   
    }
    
    
}
