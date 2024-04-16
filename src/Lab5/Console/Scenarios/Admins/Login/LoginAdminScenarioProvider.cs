using System.Diagnostics.CodeAnalysis;
using Contracts.Accounts;
using Contracts.Admins;

namespace Console.Scenarios.Admins.Login;

public class LoginAdminScenarioProvider : IScenarioProvider
{
    private readonly ILoginAdminService _loginAdminService;
    private readonly ICurrentAccountService _currentAccountService;
    private readonly ICurrentAdminService _currentAdminService;

    public LoginAdminScenarioProvider(
        ILoginAdminService loginAdminService,
        ICurrentAccountService currentAccountService,
        ICurrentAdminService currentAdminService)
    {
        _loginAdminService = loginAdminService;
        _currentAccountService = currentAccountService;
        _currentAdminService = currentAdminService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccountService.Account is not null ||
            _currentAdminService.AuthorizationStatus is AuthorizationStatus.Success)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginAdminScenario(_loginAdminService);
        return true;
    }
}