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
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<CurrentAccountService>();
        collection.AddScoped<ICurrentAccountService>(
            p => p.GetRequiredService<CurrentAccountService>());

        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<CurrentAdminService>();
        collection.AddScoped<ICurrentAdminService>(
            p => p.GetRequiredService<CurrentAdminService>());

        collection.AddScoped<IBackService, BackService>();

        return collection;
    }
}