using System.Globalization;
using Abstractions.Repositories;
using Contracts.Admins;
using Models.Accounts;
using Spectre.Console;

namespace Core.Admins;

public class ShowAllAccountsService : IShowAllAccountsService
{
    private readonly IAccountRepository _accountRepository;

    public ShowAllAccountsService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
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