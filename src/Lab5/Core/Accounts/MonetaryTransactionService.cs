using Abstractions.Repositories;
using Contracts;
using Contracts.Accounts;

namespace Core.Accounts;

public class MonetaryTransactionService : IMonetaryTransactionService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IHistoryRepository _historyRepository;
    private readonly CurrentAccountService _currentAccountService;

    public MonetaryTransactionService(
        IAccountRepository accountRepository,
        IHistoryRepository historyRepository,
        CurrentAccountService currentAccountService)
    {
        _accountRepository = accountRepository;
        _historyRepository = historyRepository;
        _currentAccountService = currentAccountService;
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
}