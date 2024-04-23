using System.Diagnostics.CodeAnalysis;
using Contracts.Accounts;
using Contracts.Admins;

namespace Console.Scenarios.Admins.Login;

public class LoginAdminScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentAccountService _currentAccountService;
    private readonly ICurrentAdminService _currentAdminService;

    public LoginAdminScenarioProvider(
        IAdminService adminService,
        ICurrentAccountService currentAccountService,
        ICurrentAdminService currentAdminService)
    {
        _adminService = adminService;
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

        scenario = new LoginAdminScenario(_adminService);
        return true;
    }
}