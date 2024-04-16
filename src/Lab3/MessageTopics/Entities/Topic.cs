using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageTopics.Entities;

public class Topic : ITopic
{
    private IAddressee _addressee;

    public Topic(string name, IAddressee addressee)
    {
        Name = name;
        _addressee = addressee;
    }

    public string Name { get; }

    public void Send(Message message)
    {
        _addressee.Send(message);
    }
}