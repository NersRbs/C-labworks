namespace Contracts.Admins;

public interface IAddAccountService
{
    Result AddAccount(int id, string pinCode);
}