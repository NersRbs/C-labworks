using System.Diagnostics.CodeAnalysis;
using Contracts.Accounts;

namespace Console.Scenarios.Accounts.GetHistory;

public class ShowHistoryScenarioProvider : IScenarioProvider
{
    private readonly IShowHistoryService _showHistoryService;
    private readonly ICurrentAccountService _currentAccountService;

    public ShowHistoryScenarioProvider(
        IShowHistoryService showHistoryService,
        ICurrentAccountService currentAccountService)
    {
        _showHistoryService = showHistoryService;
        _currentAccountService = currentAccountService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccountService.Account is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ShowHistoryScenario(_showHistoryService);
        return true;
    }
}