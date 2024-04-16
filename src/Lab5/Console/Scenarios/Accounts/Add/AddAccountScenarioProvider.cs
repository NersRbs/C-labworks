using System.Diagnostics.CodeAnalysis;
using Contracts.Admins;

namespace Console.Scenarios.Accounts.Add;

public class AddAccountScenarioProvider : IScenarioProvider
{
    private readonly IAddAccountService _addAccountService;
    private readonly ICurrentAdminService _currentAdminService;

    public AddAccountScenarioProvider(
        IAddAccountService addAccountService,
        ICurrentAdminService currentAdminService)
    {
        _addAccountService = addAccountService;
        _currentAdminService = currentAdminService;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentAdminService.AuthorizationStatus is AuthorizationStatus.Failed)
        {
            scenario = null;
            return false;
        }

        scenario = new AddAccountScenario(_addAccountService);
        return true;
    }
}