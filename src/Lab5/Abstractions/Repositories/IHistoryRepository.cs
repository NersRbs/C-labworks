using Models.Histories;

namespace Abstractions.Repositories;

public interface IHistoryRepository
{
    IAsyncEnumerable<History> GetByAccountId(long id);

    Task AddHistory(long accountId, DateTime dateTime, decimal amount);
}