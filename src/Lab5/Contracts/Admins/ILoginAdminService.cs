namespace Contracts.Admins;

public interface ILoginAdminService
{
    Result Login(string pinCode);
}