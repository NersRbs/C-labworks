using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers.Entities;

 public class LogDecorator : IAddressee
 {
     private readonly ILogger _logger;
     private readonly IAddressee _addressee;

     public LogDecorator(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

     public void Send(Message message)
    {
        _logger.Log(message);
        _addressee.Send(message);
    }
}