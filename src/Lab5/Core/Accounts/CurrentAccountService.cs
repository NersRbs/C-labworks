using Contracts.Accounts;
using Models.Accounts;

namespace Core.Accounts;

public class CurrentAccountService : ICurrentAccountService
{
    public Account? Account { get; set; }
}