namespace Contracts.Accounts;

public interface IAccountService
{
    Result Login(long id, string pinCode);
    Task<Result> AddMonetaryTransaction(decimal amount);
    Task ShowHistory();
}