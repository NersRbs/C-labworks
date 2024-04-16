using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Models.Speed;

public class ExponentialSpeed : ISpeed
{
    public Time CalculateTime(double distance)
    {
        double time = Math.Log(distance + 1, Math.E);
        return time;
    }
}