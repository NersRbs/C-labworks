using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;

public class Messenger : IMessenger
{
    public void Input(string message)
    {
        Console.WriteLine("Messenger:\n" + message);
    }
}