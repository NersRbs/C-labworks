using Contracts.Admins;
using Spectre.Console;

namespace Console.Scenarios.Admins.SetNewPin;

public class SetNewPinScenario : IScenario
{
    private readonly ISetNewPinService _setNewPinService;
    public SetNewPinScenario(ISetNewPinService setNewPinService)
    {
        _setNewPinService = setNewPinService;
    }

    public string Name => "Set new pin";
    public void Run()
    {
        string pinCode = AnsiConsole.Ask<string>("Enter new pin code: ");
        _setNewPinService.SetNewPin(pinCode);
        AnsiConsole.MarkupLine("[green]Pin code set successfully[/]");
        System.Console.ReadLine();
    }
}