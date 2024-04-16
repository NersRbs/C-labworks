using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models.Speed;
using Itmo.ObjectOrientedProgramming.Lab1.Fuels.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities.PulseEngine;

public class PulseEngineC : IPulseEngine
{
    public TimeAndFuel Calculate(double distance)
    {
        var speed = new ConstSpeed(50);
        Time time = speed.CalculateTime(distance);
        var fuel = new ActivePlasma(distance / speed.CalculateTime(distance).Data);
        return new TimeAndFuel(time, fuel);
    }
}