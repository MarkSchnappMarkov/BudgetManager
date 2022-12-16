using BudgetManager2.Veiws;

namespace BudgetManager2;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(AddExpense), typeof(AddExpense));
        Routing.RegisterRoute(nameof(AddIncome), typeof(AddIncome));
    }
}

