using Contracts.Admins;

namespace Console.Scenarios.Admins.ShowAllAccounts;

public class ShowAllAccountScenarios : IScenario
{
    private readonly IShowAllAccountsService _showAllAccountsService;
    public ShowAllAccountScenarios(IShowAllAccountsService showAllAccountsService)
    {
        _showAllAccountsService = showAllAccountsService;
    }

    public string Name => "Show all accounts";
    public void Run()
    {
        _showAllAccountsService.ShowAllAccounts();
        System.Console.ReadLine();
    }
}