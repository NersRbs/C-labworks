using Console;
using Console.Extensions;
using Core.Extensions;
using Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

var collection = new ServiceCollection();

collection
    .AddApplication()
    .AddInfrastructureDataAccess(configuration =>
    {
        configuration.Host = "localhost";
        configuration.Port = 6432;
        configuration.Username = "postgres";
        configuration.Password = "postgres";
        configuration.Database = "postgres";
        configuration.SslMode = "Prefer";
    })
    .AddPresentationConsole();

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

scope.UseInfrastructureDataAccess();

ScenarioRunner runner = scope.ServiceProvider
    .GetRequiredService<ScenarioRunner>();

while (true)
{
    runner.Run();
    AnsiConsole.Clear();
}