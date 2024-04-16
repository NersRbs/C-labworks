using Itmo.ObjectOrientedProgramming.Lab2.Computers.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Configurators.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Configurators.Entities;

public interface IConfiguratorChecker
{
    Status Check(IComputer computer);
}