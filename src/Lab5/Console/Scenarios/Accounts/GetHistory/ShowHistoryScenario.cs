using Contracts.Accounts;

namespace Console.Scenarios.Accounts.GetHistory;

public class ShowHistoryScenario : IScenario
{
    private readonly IAccountService _accountService;

    public ShowHistoryScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Get history";
    public void Run()
    {
        _accountService.ShowHistory();
        System.Console.ReadLine();
    }
}