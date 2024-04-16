namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

public class MessageWithStatus
{
    public MessageWithStatus(string message)
    {
        Message = message;
        Status = MessageStatus.NotRead;
    }

    public string Message { get; }
    public MessageStatus Status { get; private set; }
    public MessageResult ChangeStatus(MessageStatus status)
    {
        if (Status is MessageStatus.Read)
        {
            return new MessageResult.MessageAlreadyRead();
        }

        Status = status;
        return new MessageResult.Success();
    }
}