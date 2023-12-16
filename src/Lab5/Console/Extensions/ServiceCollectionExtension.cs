using Console.Scenarios;
using Console.Scenarios.AccountLogout;
using Console.Scenarios.AdminLogin;
using Console.Scenarios.Balance;
using Console.Scenarios.CheckoutAccount;
using Console.Scenarios.CreateAccount;
using Console.Scenarios.DepositMoney;
using Console.Scenarios.Login;
using Console.Scenarios.Logout;
using Console.Scenarios.OperationHistory;
using Console.Scenarios.Registration;
using Console.Scenarios.WithdrawMoney;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, SignUpScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckOutAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();

        return collection;
    }
}