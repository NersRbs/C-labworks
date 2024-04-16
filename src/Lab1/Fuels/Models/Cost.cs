namespace Itmo.ObjectOrientedProgramming.Lab1.Fuels.Models;

public class Cost
{
    public Cost(double value)
    {
        Data = value;
    }

    public double Data { get; }

    public static implicit operator Cost(double value)
    {
        return new Cost(value);
    }

    public static Cost operator +(Cost left, Cost right)
    {
        return new Cost(left.Data + right.Data);
    }

    public static Cost operator *(Cost left, Cost right)
    {
        return new Cost(left.Data * right.Data);
    }

    public static Cost Add(Cost left, Cost right)
    {
        return left + right;
    }

    public static Cost Multiply(Cost left, Cost right)
    {
        return left * right;
    }

    public Cost ToCost()
    {
        return new Cost(Data);
    }
}