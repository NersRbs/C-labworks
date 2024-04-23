using System.Diagnostics.CodeAnalysis;
using Contracts.Admins;

namespace Console.Scenarios.Admins.SetNewPin;

public class SetNewPinScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentAdminService _currentAdminService;

    public SetNewPinScenarioProvider(
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

        scenario = new SetNewPinScenario(_adminService);
        return true;
    }
}