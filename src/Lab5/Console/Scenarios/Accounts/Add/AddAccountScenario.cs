using Contracts;
using Contracts.Admins;
using Spectre.Console;

namespace Console.Scenarios.Accounts.Add;

public class AddAccountScenario : IScenario
{
    private readonly IAddAccountService _addAccountService;

    public AddAccountScenario(IAddAccountService addAccountService)
    {
        _addAccountService = addAccountService;
    }

    public string Name => "Add account";
    public void Run()
    {
        string id = AnsiConsole.Ask<string>("Enter your id:\n");
        string pinCode = AnsiConsole.Ask<string>("Enter your pin code:\n");

        if (int.TryParse(id, out int parsedId) is false)
        {
            AnsiConsole.MarkupLine("[red]Invalid id[/]");
            System.Console.ReadLine();
            return;
        }

        Result result = _addAccountService.AddAccount(parsedId, pinCode);
        string message = result switch
        {
            Result.Success => "[green]Add account successful[/]",
            Result.Failed => "[red]Account already exists[/]",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.MarkupLine(message);
        System.Console.ReadLine();
    }
}