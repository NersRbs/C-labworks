using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Tests
{
    [Fact]
    public void Message_ShouldReturnNotRead()
    {
        // Arrange
        var user = new User("No", "Name", 18);
        var message = new Message("Header", "Body", new ImportanceLevel.Medium());
        var addresseeUser = new AddresseeUser(user);

        // Act
        addresseeUser.Send(message);

        // Assert
        Assert.Equal(MessageStatus.NotRead, user.Messages.First().Status);
    }

    [Fact]
    public void Message_ShouldReturnRead()
    {
        // Arrange
        var user = new User("No", "Name", 18);
        var message = new Message("Header", "Body", new ImportanceLevel.Medium());
        var addresseeUser = new AddresseeUser(user);

        // Act
        addresseeUser.Send(message);
        user.Messages.First().ChangeStatus(MessageStatus.Read);

        // Assert
        Assert.Equal(MessageStatus.Read, user.Messages.First().Status);
    }

    [Fact]
    public void Message_ShouldReturnError()
    {
        // Arrange
        var user = new User("No", "Name", 18);
        var message = new Message("Header", "Body", new ImportanceLevel.Medium());
        var addresseeUser = new AddresseeUser(user);

        // Act
        addresseeUser.Send(message);
        user.Messages.First().ChangeStatus(MessageStatus.Read);

        // Assert
        MessageResult result = user.Messages.First().ChangeStatus(MessageStatus.Read);
        Assert.Equal(new MessageResult.MessageAlreadyRead(), result);
    }

    [Fact]
    public void Filter_ShouldReturnDoNotReceive()
    {
        // Arrange
        IAddressee? addresseeMock = Substitute.For<IAddressee>();
        IAddressee proxyFiler = new WrappedAddresseeBuilder()
            .SetAddressees(addresseeMock)
            .AddFilter(new ImportanceLevel.High())
            .Build();
        var message = new Message("Header", "Body", new ImportanceLevel.Medium());

        // Act
        proxyFiler.Send(message);

        // Assert
        addresseeMock.DidNotReceive().Send(message);
    }

    [Fact]
    public void Log_ShouldReturnReceive()
    {
        // Arrange
        IAddressee? addresseeMock = Substitute.For<IAddressee>();
        IAddressee logDecorator = new WrappedAddresseeBuilder()
            .SetAddressees(addresseeMock)
            .AddLog(new Logger())
            .Build();
        var message = new Message("Header", "Body", new ImportanceLevel.Medium());

        // Act
        logDecorator.Send(message);

        // Assert
        addresseeMock.Received().Send(message);
    }

    [Fact]
    public void Messenger_ShouldInput()
    {
        // Arrange
        IMessenger? messengerMock = Substitute.For<IMessenger>();
        var addresseeMessenger = new AddresseeMessenger(messengerMock);
        var message = new Message("Header", "Body", new ImportanceLevel.Medium());

        // Act
        addresseeMessenger.Send(message);

        // Assert
        messengerMock.Received().Input(message.ToString());
    }
}