using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Entities;

public class User : IUser
{
    private IList<MessageWithStatus> _messages;
    public User(string firstName, string lastName, int age)
    {
        if (age < 0)
        {
            throw new ArgumentException("Age cannot be less than zero");
        }

        FirstName = firstName;
        LastName = lastName;
        Age = age;
        _messages = new List<MessageWithStatus>();
    }

    public string FirstName { get; }
    public string LastName { get; }
    public int Age { get; }
    public IReadOnlyCollection<MessageWithStatus> Messages => _messages.AsReadOnly();

    public void Accept(string message)
    {
        _messages.Add(new MessageWithStatus(message));
    }
}