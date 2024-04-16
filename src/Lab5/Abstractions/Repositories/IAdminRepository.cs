namespace Abstractions.Repositories;

public interface IAdminRepository
{
    Task<string?> GetPinCode();

    Task SetPinCode(string pinCode);
}