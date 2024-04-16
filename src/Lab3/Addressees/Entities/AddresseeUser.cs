using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class AddresseeUser : IAddressee
{
    private readonly IUser _user;

    public AddresseeUser(IUser user)
    {
        _user = user;
    }

    public void Send(Message message)
    {
        _user.Accept(message.ToString());
    }
}