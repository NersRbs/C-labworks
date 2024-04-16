using Contracts.Admins;

namespace Core.Admins;

public class CurrentAdminService : ICurrentAdminService
{
    public AuthorizationStatus AuthorizationStatus { get; set; } = AuthorizationStatus.Failed;
}