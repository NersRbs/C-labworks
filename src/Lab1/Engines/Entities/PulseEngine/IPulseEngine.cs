using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities.PulseEngine;

public interface IPulseEngine
{
    TimeAndFuel Calculate(double distance);
}