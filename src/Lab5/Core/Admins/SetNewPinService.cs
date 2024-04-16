using Abstractions.Repositories;
using Contracts.Admins;

namespace Core.Admins;

public class SetNewPinService : ISetNewPinService
{
    private readonly IAdminRepository _repository;
    public SetNewPinService(IAdminRepository repository)
    {
        _repository = repository;
    }

    public void SetNewPin(string pinCode)
    {
        _repository.SetPinCode(pinCode);
    }
}