using Itmo.ObjectOrientedProgramming.Lab4.Parser.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities.CommandBuilders;

public interface ICommandBuilder
{
    ParseCommandStatus Build();
}