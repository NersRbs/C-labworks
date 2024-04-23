using System.Globalization;
using Abstractions.Repositories;
using Contracts;
using Contracts.Admins;
using Models.Accounts;
using Spectre.Console;

namespace Core.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly CurrentAdminService _currentAccountService;

    public AdminService(IAdminRepository adminRepository, IAccountRepository accountRepository, CurrentAdminService currentAccountService)
    {
        _adminRepository = adminRepository;
        _accountRepository = accountRepository;
        _currentAccountService = currentAccountService;
    }

    public Result Login(string pinCode)
    {
        Task<string?> hashedPinCode = _adminRepository.GetPinCode();

        if (hashedPinCode.Result is null || BCrypt.Net.BCrypt.Verify(pinCode, hashedPinCode.Result) is false)
        {
            return new Result.Failed();
        }

        _currentAccountService.AuthorizationStatus = AuthorizationStatus.Success;
        return new Result.Success();
    }

    public Result AddAccount(int id, string pinCode)
    {
        if (_accountRepository.GetById(id).Result is not null)
        {
            return new Result.Failed();
        }

        _accountRepository.AddNewUser(id, pinCode);
        return new Result.Success();
    }

    public void SetNewPin(string pinCode)
    {
        _adminRepository.SetPinCode(pinCode);
    }

    public async Task ShowAllAccounts()
    {
        IAsyncEnumerable<Account> accounts = _accountRepository.GetAll();

        Table table = new Table().Centered();
        await AnsiConsole.Live(table)
            .StartAsync(async ctx =>
            {
                // Add table headers
                table.AddColumn("ID");
                table.AddColumn("Hashed Pin Code");
                table.AddColumn("Balance");

                // Get the current culture's format provider
                IFormatProvider formatProvider = CultureInfo.CurrentCulture;

                // Retrieve and display account information
                await foreach (Account account in accounts.ConfigureAwait(false))
                {
                    table.AddRow(
                        account.Id.ToString(formatProvider),
                        account.HashedPinCode,
                        account.Balance.ToString("C", formatProvider));

                    // Refresh the table to display updates
                    ctx.Refresh();
                }
            }).ConfigureAwait(false);
    }
}