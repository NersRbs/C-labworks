using System.Diagnostics.CodeAnalysis;
using Contracts.Admins;

namespace Console.Scenarios.Admins.ShowAllAccounts;

public class ShowAllAccountScenariosProvider : IScenarioProvider
{
    private readonly IShowAllAccountsService _showAllAccountsService;
    private readonly ICurrentAdminService _currentAdminService;

    public ShowAllAccountScenariosProvider(
        IShowAllAccountsService showAllAccountsService,
        ICurrentAdminService currentAdminService)
    {
        _showAllAccountsService = showAllAccountsService;
        _currentAdminService = currentAdminService;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentAdminService.AuthorizationStatus is AuthorizationStatus.Failed)
        {
            scenario = null;
            return false;
        }

        scenario = new ShowAllAccountScenarios(_showAllAccountsService);
        return true;
    }
}