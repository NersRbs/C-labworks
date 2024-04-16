using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class AddresseeMessenger : IAddressee
{
    private IMessenger _messenger;

    public AddresseeMessenger(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void Send(Message message)
    {
        _messenger.Input(message.ToString());
    }
}