using Abstractions.Repositories;
using Contracts;
using Contracts.Admins;

namespace Core.Admins;

public class AddAccountService : IAddAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AddAccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
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
}