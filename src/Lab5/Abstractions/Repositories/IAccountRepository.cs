using Models.Accounts;

namespace Abstractions.Repositories;

public interface IAccountRepository
{
    Task<Account?> GetById(long id);

    IAsyncEnumerable<Account> GetAll();

    Task AddNewUser(int id, string pinCode);

    Task Update(Account account);

    Task RemoveById(long id);
}