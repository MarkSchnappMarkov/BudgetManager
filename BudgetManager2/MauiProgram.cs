using BudgetManager2.Services;
using BudgetManager2.Veiws;
using BudgetManager2.ViewModels;
using Microsoft.Extensions.Logging;
using SQLitePCL;

namespace BudgetManager2;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                raw.SetProvider(new SQLite3Provider_sqlite3());
            });

#if DEBUG
        builder.Logging.AddDebug();

#endif
        //registration
        builder.Services.AddSingleton<BudgetManagerMainPage>();
        builder.Services.AddSingleton<BudgetManagerMainPageViewModel>();

        builder.Services.AddTransient<AddExpense>();
        builder.Services.AddTransient<AddExpenseViewModel>();

        builder.Services.AddTransient<AddIncome>();
        builder.Services.AddTransient<AddIncomeViewModel>();

        builder.Services.AddSingleton<IBudgetManagerServices, BudgetManagerServices>();

        

        return builder.Build();
    }
}

