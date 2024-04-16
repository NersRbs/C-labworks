using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Entities;

public interface ICommand
{
    CommandStatus Execute(IContext context);
}