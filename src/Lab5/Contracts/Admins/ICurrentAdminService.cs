namespace Contracts.Admins;

public interface ICurrentAdminService
{
    public AuthorizationStatus AuthorizationStatus { get; }
}