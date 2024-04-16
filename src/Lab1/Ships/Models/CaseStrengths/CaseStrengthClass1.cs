namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.CaseStrengths;

public class CaseStrengthClass1 : ICaseStrength
{
    public HealthPoints HealthPoints { get; } = 10;
    public uint GetCoefficient(uint damage)
    {
        switch (damage)
        {
            case <= 1: return 10;
            default: return 100;
        }
    }

    public void TakeDamage(uint damage)
    {
        uint coefficient;
        switch (damage)
        {
            case <= 1:
                coefficient = 10;
                break;
            default:
                coefficient = 100;
                break;
        }

        HealthPoints.Damage(damage * coefficient);
    }
}