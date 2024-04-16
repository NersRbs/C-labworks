using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Entities;

public interface IUser
{
    IReadOnlyCollection<MessageWithStatus> Messages { get; }
    void Accept(string message);
}