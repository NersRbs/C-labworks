using System.Diagnostics.CodeAnalysis;
using Contracts.Accounts;

namespace Console.Scenarios.Accounts.MonetaryTransaction;

public class MonetaryTransactionScenarioProvider : IScenarioProvider
{
    private readonly IMonetaryTransactionService _monetaryTransactionService;
    private readonly ICurrentAccountService _currentAccountService;

    public MonetaryTransactionScenarioProvider(
        IMonetaryTransactionService monetaryTransactionService,
        ICurrentAccountService currentAccountService)
    {
        _monetaryTransactionService = monetaryTransactionService;
        _currentAccountService = currentAccountService;
    }

    public bool TryGetScenario([NotNullWhen(true)]out IScenario? scenario)
    {
        if (_currentAccountService.Account is null)
        {
            scenario = null;
            return false;
        }

        scenario = new MonetaryTransactionScenario(_monetaryTransactionService);
        return true;
    }
}