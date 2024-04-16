using Abstractions.Repositories;
using Contracts;
using Contracts.Admins;

namespace Core.Admins;

public class LoginAdminService : ILoginAdminService
{
    private readonly IAdminRepository _repository;
    private readonly CurrentAdminService _currentAccountService;

    public LoginAdminService(IAdminRepository repository, CurrentAdminService currentAccountService)
    {
        _repository = repository;
        _currentAccountService = currentAccountService;
    }

    public Result Login(string pinCode)
    {
        Task<string?> hashedPinCode = _repository.GetPinCode();

        if (hashedPinCode.Result is null || BCrypt.Net.BCrypt.Verify(pinCode, hashedPinCode.Result) is false)
        {
            return new Result.Failed();
        }

        _currentAccountService.AuthorizationStatus = AuthorizationStatus.Success;
        return new Result.Success();
    }
}