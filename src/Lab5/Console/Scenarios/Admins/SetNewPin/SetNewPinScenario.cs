using Contracts.Admins;
using Spectre.Console;

namespace Console.Scenarios.Admins.SetNewPin;

public class SetNewPinScenario : IScenario
{
    private readonly IAdminService _adminService;
    public SetNewPinScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Set new pin";
    public void Run()
    {
        string pinCode = AnsiConsole.Ask<string>("Enter new pin code: ");
        _adminService.SetNewPin(pinCode);
        AnsiConsole.MarkupLine("[green]Pin code set successfully[/]");
        System.Console.ReadLine();
    }
}