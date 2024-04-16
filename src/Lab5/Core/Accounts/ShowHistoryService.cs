using System.Globalization;
using Abstractions.Repositories;
using Contracts.Accounts;
using Models.Histories;
using Spectre.Console;

namespace Core.Accounts;

public class ShowHistoryService : IShowHistoryService
{
    private readonly IHistoryRepository _historyRepository;
    private readonly CurrentAccountService _currentAccountService;

    public ShowHistoryService(
        IHistoryRepository historyRepository,
        CurrentAccountService currentAccountService)
    {
        _historyRepository = historyRepository;
        _currentAccountService = currentAccountService;
    }

    public async Task ShowHistory()
    {
        if (_currentAccountService.Account is null)
        {
            return;
        }

        IAsyncEnumerable<History> histories = _historyRepository.GetByAccountId(_currentAccountService.Account.Id);

        Table table = new Table().Centered();
        await AnsiConsole.Live(table)
            .StartAsync(async ctx =>
            {
                table.AddColumn("ID");
                table.AddColumn("Account ID");
                table.AddColumn("Date");
                table.AddColumn("Amount");
                IFormatProvider formatProvider = CultureInfo.CurrentCulture;

                await foreach (History history in histories.ConfigureAwait(false))
                {
                    table.AddRow(
                        history.Id.ToString(formatProvider),
                        history.AccountId.ToString(formatProvider),
                        history.Date.ToString(formatProvider),
                        history.Amount.ToString("C", formatProvider));

                    ctx.Refresh();
                }
            }).ConfigureAwait(false);
    }
}