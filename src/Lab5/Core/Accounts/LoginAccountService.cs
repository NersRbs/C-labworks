using Abstractions.Repositories;
using Contracts;
using Contracts.Accounts;
using Models.Accounts;

namespace Core.Accounts;

public class LoginAccountService : ILoginAccountService
{
    private readonly IAccountRepository _repository;
    private readonly CurrentAccountService _currentAccountService;

    public LoginAccountService(IAccountRepository repository, CurrentAccountService currentAccountService)
    {
        _repository = repository;
        _currentAccountService = currentAccountService;
    }

    public Result Login(long id, string pinCode)
    {
        Task<Account?> account = _repository.GetById(id);

        if (account.Result is null || BCrypt.Net.BCrypt.Verify(pinCode, account.Result.HashedPinCode) is false)
        {
            return new Result.Failed();
        }

        _currentAccountService.Account = account.Result;
        return new Result.Success();
    }
}