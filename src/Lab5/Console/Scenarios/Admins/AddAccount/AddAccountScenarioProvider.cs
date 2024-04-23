using System.Diagnostics.CodeAnalysis;
using Contracts.Admins;

namespace Console.Scenarios.Accounts.Add;

public class AddAccountScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentAdminService _currentAdminService;

    public AddAccountScenarioProvider(
        IAdminService adminService,
        ICurrentAdminService currentAdminService)
    {
        _adminService = adminService;
        _currentAdminService = currentAdminService;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentAdminService.AuthorizationStatus is AuthorizationStatus.Failed)
        {
            scenario = null;
            return false;
        }

        scenario = new AddAccountScenario(_adminService);
        return true;
    }
}