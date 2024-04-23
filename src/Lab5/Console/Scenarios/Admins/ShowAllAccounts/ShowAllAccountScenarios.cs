using Contracts.Admins;

namespace Console.Scenarios.Admins.ShowAllAccounts;

public class ShowAllAccountScenarios : IScenario
{
    private readonly IAdminService _adminService;
    public ShowAllAccountScenarios(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Show all accounts";
    public void Run()
    {
        _adminService.ShowAllAccounts();
        System.Console.ReadLine();
    }
}