using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models.Speed;
using Itmo.ObjectOrientedProgramming.Lab1.Fuels.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities.JumpEngine;

public class OmegaEngine : IJumpEngine
{
    private const double DistanceLimit = 5000;
    public TimeAndFuel Calculate(double distance)
    {
        var speed = new ConstSpeed(50);
        Time time = speed.CalculateTime(distance);
        var fuel = new GravitonMatter(distance / speed.CalculateTime(distance).Data);
        return new TimeAndFuel(time, fuel);
    }

    public bool CanOvercome(double distance)
    {
        return distance <= DistanceLimit;
    }
}