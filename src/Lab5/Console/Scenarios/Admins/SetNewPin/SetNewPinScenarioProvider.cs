using System.Diagnostics.CodeAnalysis;
using Contracts.Admins;

namespace Console.Scenarios.Admins.SetNewPin;

public class SetNewPinScenarioProvider : IScenarioProvider
{
    private readonly ISetNewPinService _setNewPinService;
    private readonly ICurrentAdminService _currentAdminService;

    public SetNewPinScenarioProvider(
        ISetNewPinService setNewPinService,
        ICurrentAdminService currentAdminService)
    {
        _setNewPinService = setNewPinService;
        _currentAdminService = currentAdminService;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentAdminService.AuthorizationStatus is AuthorizationStatus.Failed)
        {
            scenario = null;
            return false;
        }

        scenario = new SetNewPinScenario(_setNewPinService);
        return true;
    }
}