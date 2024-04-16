using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageTopics.Entities;

public interface ITopic
{
    void Send(Message message);
}