using Console.Scenarios.Accounts.Add;
using Console.Scenarios.Accounts.GetHistory;
using Console.Scenarios.Accounts.Login;
using Console.Scenarios.Accounts.MonetaryTransaction;
using Console.Scenarios.Admins.Login;
using Console.Scenarios.Admins.SetNewPin;
using Console.Scenarios.Admins.ShowAllAccounts;
using Console.Scenarios.Back;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, BackScenarioProvider>();
        collection.AddScoped<IScenarioProvider, SetNewPinScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowAllAccountScenariosProvider>();
        collection.AddScoped<IScenarioProvider, MonetaryTransactionScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowHistoryScenarioProvider>();

        return collection;
    }
}