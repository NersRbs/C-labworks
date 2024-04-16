﻿using Contracts;
using Contracts.Admins;
using Spectre.Console;

namespace Console.Scenarios.Admins.Login;

public class LoginAdminScenario : IScenario
{
    private readonly ILoginAdminService _loginAdminService;

    public LoginAdminScenario(ILoginAdminService loginAdminService)
    {
        _loginAdminService = loginAdminService;
    }

    public string Name => "Admin";
    public void Run()
    {
        string pinCode = AnsiConsole.Ask<string>("Enter your pin code: ");

        Result result = _loginAdminService.Login(pinCode);
        string message = result switch
        {
            Result.Success => "[green]Login successful[/]",
            Result.Failed => "[red]Login failed[/]",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.MarkupLine(message);
        System.Console.ReadLine();
    }
}