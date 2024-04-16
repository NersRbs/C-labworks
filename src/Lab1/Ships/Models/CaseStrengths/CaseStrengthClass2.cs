namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.CaseStrengths;

public class CaseStrengthClass2 : ICaseStrength
{
    public HealthPoints HealthPoints { get; } = 50;
    public uint GetCoefficient(uint damage)
    {
        switch (damage)
        {
            case <= 1: return 10;
            case <= 5: return 5;
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
            case <= 5:
                coefficient = 5;
                break;
            default:
                coefficient = 100;
                break;
        }

        HealthPoints.Damage(damage * coefficient);
    }
}