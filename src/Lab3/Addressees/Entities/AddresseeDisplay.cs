using Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class AddresseeDisplay : IAddressee
{
    private readonly IDisplay _display;

    public AddresseeDisplay(IDisplay display)
    {
        _display = display;
    }

    public void Send(Message message)
    {
        _display.Input(message.ToString());
    }
}