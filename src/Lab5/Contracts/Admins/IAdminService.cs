namespace Contracts.Admins;

public interface IAdminService
{
    Result Login(string pinCode);
    Result AddAccount(int id, string pinCode);
    void SetNewPin(string pinCode);
    Task ShowAllAccounts();
}