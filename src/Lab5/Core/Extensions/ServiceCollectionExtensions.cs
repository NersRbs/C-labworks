using Contracts;
using Contracts.Accounts;
using Contracts.Admins;
using Core.Accounts;
using Core.Admins;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<ILoginAccountService, LoginAccountService>();
        collection.AddScoped<CurrentAccountService>();
        collection.AddScoped<ICurrentAccountService>(
            p => p.GetRequiredService<CurrentAccountService>());

        collection.AddScoped<ILoginAdminService, LoginAdminService>();
        collection.AddScoped<CurrentAdminService>();
        collection.AddScoped<ICurrentAdminService>(
            p => p.GetRequiredService<CurrentAdminService>());

        collection.AddScoped<IBackService, BackService>();
        collection.AddScoped<ISetNewPinService, SetNewPinService>();
        collection.AddScoped<IAddAccountService, AddAccountService>();
        collection.AddScoped<IShowAllAccountsService, ShowAllAccountsService>();

        collection.AddScoped<IMonetaryTransactionService, MonetaryTransactionService>();
        collection.AddScoped<IShowHistoryService, ShowHistoryService>();
        return collection;
    }
}