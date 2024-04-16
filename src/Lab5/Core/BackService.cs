using Contracts;
using Contracts.Admins;
using Core.Accounts;
using Core.Admins;

namespace Core;

public class BackService : IBackService
{
    private readonly CurrentAccountService _currentAccountService;
    private readonly CurrentAdminService _currentAdminService;

    public BackService(
        CurrentAccountService currentAccountService,
        CurrentAdminService currentAdminService)
    {
        _currentAccountService = currentAccountService;
        _currentAdminService = currentAdminService;
    }

    public void Back()
    {
        _currentAccountService.Account = null;
        _currentAdminService.AuthorizationStatus = AuthorizationStatus.Failed;
    }
}