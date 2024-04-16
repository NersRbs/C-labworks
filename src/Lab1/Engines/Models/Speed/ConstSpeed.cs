namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Models.Speed;

public class ConstSpeed : ISpeed
{
    private readonly double _data;
    public ConstSpeed(double speed)
    {
        _data = speed;
    }

    public Time CalculateTime(double distance)
    {
        return new Time(distance / _data);
    }
}