namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;

public class Time
{
    public Time(double data)
    {
        Data = data;
    }

    public double Data { get; }

    public static implicit operator Time(double data)
    {
        return new Time(data);
    }

    public static Time operator +(Time left, Time right)
    {
        return new Time(left.Data + right.Data);
    }

    public static Time operator -(Time left, Time right)
    {
        return new Time(left.Data - right.Data);
    }

    public static Time Add(Time left, Time right)
    {
        return left + right;
    }

    public static Time Subtract(Time left, Time right)
    {
        return left - right;
    }

    public Time ToTime()
    {
        return new Time(Data);
    }
}