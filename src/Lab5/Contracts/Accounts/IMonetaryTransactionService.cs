namespace Contracts.Accounts;

public interface IMonetaryTransactionService
{
    Task<Result> AddMonetaryTransaction(decimal amount);
}