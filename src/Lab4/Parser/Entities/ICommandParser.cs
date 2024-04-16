using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities;

public interface ICommandParser
{
    ParseCommandStatus Parse(string line);
}