using System.Diagnostics.CodeAnalysis;
using Contracts;
using Contracts.Accounts;
using Contracts.Admins;

namespace Console.Scenarios.Back;

public class BackScenarioProvider : IScenarioProvider
{
    private readonly IBackService _backService;
    private readonly ICurrentAccountService _currentAccountService;
    private readonly ICurrentAdminService _currentAdminService;

    public BackScenarioProvider(
        IBackService backService,
        ICurrentAccountService currentAccountService,
        ICurrentAdminService currentAdminService)
    {
        _backService = backService;
        _currentAccountService = currentAccountService;
        _currentAdminService = currentAdminService;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentAccountService.Account is null &&
            _currentAdminService.AuthorizationStatus is AuthorizationStatus.Failed)
        {
            scenario = null;
            return false;
        }

        scenario = new BackScenario(_backService);
        return true;
    }
}