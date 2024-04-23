using System.Globalization;
using Abstractions.Repositories;
using Contracts;
using Contracts.Accounts;
using Models.Accounts;
using Models.Histories;
using Spectre.Console;

namespace Core.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IHistoryRepository _historyRepository;
    private readonly CurrentAccountService _currentAccountService;

    public AccountService(
        IAccountRepository repository,
        IHistoryRepository historyRepository,
        CurrentAccountService currentAccountService)
    {
        _accountRepository = repository;
        _historyRepository = historyRepository;
        _currentAccountService = currentAccountService;
    }

    public Result Login(long id, string pinCode)
    {
        Task<Account?> account = _accountRepository.GetById(id);

        if (account.Result is null || BCrypt.Net.BCrypt.Verify(pinCode, account.Result.HashedPinCode) is false)
        {
            return new Result.Failed();
        }

        _currentAccountService.Account = account.Result;
        return new Result.Success();
    }

    public async Task<Result> AddMonetaryTransaction(decimal amount)
    {
        if (_currentAccountService.Account is null || _currentAccountService.Account.Balance + amount < 0)
        {
            return new Result.Failed();
        }

        _currentAccountService.Account = _currentAccountService.Account with { Balance = _currentAccountService.Account.Balance + amount };

        await _accountRepository.Update(_currentAccountService.Account).ConfigureAwait(false);

        await _historyRepository.AddHistory(
            _currentAccountService.Account.Id,
            DateTime.Now,
            amount).ConfigureAwait(false);

        return new Result.Success();
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