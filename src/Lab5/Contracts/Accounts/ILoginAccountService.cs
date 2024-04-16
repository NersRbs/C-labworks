namespace Contracts.Accounts;

public interface ILoginAccountService
{
    Result Login(long id, string pinCode);
}