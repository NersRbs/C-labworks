using Abstractions.Repositories;
using Contracts;
using Core.Accounts;
using Models.Accounts;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Tests
{
    [Fact]
    public void Withdraw_ShouldResultSuccess()
    {
        // Arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IHistoryRepository historyRepository = Substitute.For<IHistoryRepository>();
        var currentAccountService = new CurrentAccountService();

        currentAccountService.Account = new Account(1, "1234", 200);

        // Act
        var service = new AccountService(accountRepository, historyRepository, currentAccountService);
        Result result = service.AddMonetaryTransaction(-100).GetAwaiter().GetResult();

        // Assert
        Assert.True(result is Result.Success);
        Assert.Equal(100, currentAccountService.Account.Balance);
    }

    [Fact]
    public void Withdraw_ShouldResultFailed()
    {
        // Arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IHistoryRepository historyRepository = Substitute.For<IHistoryRepository>();
        var currentAccountService = new CurrentAccountService();

        currentAccountService.Account = new Account(1, "1234", 200);

        // Act
        var service = new AccountService(accountRepository, historyRepository, currentAccountService);
        Result result = service.AddMonetaryTransaction(-300).GetAwaiter().GetResult();

        // Assert
        Assert.True(result is Result.Failed);
    }

    [Fact]
    public void Replenish_ShouldResultSuccess()
    {
        // Arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IHistoryRepository historyRepository = Substitute.For<IHistoryRepository>();
        var currentAccountService = new CurrentAccountService();

        currentAccountService.Account = new Account(1, "1234", 200);

        // Act
        var service = new AccountService(accountRepository, historyRepository, currentAccountService);
        Result result = service.AddMonetaryTransaction(100).GetAwaiter().GetResult();

        // Assert
        Assert.True(result is Result.Success);
        Assert.Equal(300, currentAccountService.Account.Balance);
    }
}