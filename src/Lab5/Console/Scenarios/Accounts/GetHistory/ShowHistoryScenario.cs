using Contracts.Accounts;

namespace Console.Scenarios.Accounts.GetHistory;

public class ShowHistoryScenario : IScenario
{
    private readonly IShowHistoryService _showHistoryService;

    public ShowHistoryScenario(IShowHistoryService showHistoryService)
    {
        _showHistoryService = showHistoryService;
    }

    public string Name => "Get history";
    public void Run()
    {
        _showHistoryService.ShowHistory();
        System.Console.ReadLine();
    }
}