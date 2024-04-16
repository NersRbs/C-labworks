using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities.JumpEngine;

public interface IJumpEngine
{
    TimeAndFuel Calculate(double distance);
    bool CanOvercome(double distance);
}