using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;

public class Logger : ILogger
{
    public void Log(Message message)
    {
        Console.WriteLine($"Message sent {message}");
    }
}