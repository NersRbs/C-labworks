using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;

public class ProxyFilter : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ImportanceLevel _importanceLevel;

    public ProxyFilter(IAddressee addressee, ImportanceLevel importanceLevel)
    {
        _addressee = addressee;
        _importanceLevel = importanceLevel;
    }

    public void Send(Message message)
    {
        if (message.ImportanceLevel.Level >= _importanceLevel.Level)
        {
            _addressee.Send(message);
        }
    }
}