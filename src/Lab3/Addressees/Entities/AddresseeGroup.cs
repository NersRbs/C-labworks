using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class AddresseeGroup : IAddressee
{
    private readonly List<IAddressee> _addressees = new();

    public void Add(IAddressee addressee)
    {
        _addressees.Add(addressee);
    }

    public void Remove(IAddressee addressee)
    {
        _addressees.Remove(addressee);
    }

    public void Send(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.Send(message);
        }
    }
}