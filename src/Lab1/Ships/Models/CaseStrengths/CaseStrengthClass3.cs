namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.CaseStrengths;

public class CaseStrengthClass3 : ICaseStrength
{
    public HealthPoints HealthPoints { get; } = 100;
    public uint GetCoefficient(uint damage)
    {
        switch (damage)
        {
            case <= 1: return 5;
            case <= 5: return 4;
            default: return 100;
        }
    }

    public void TakeDamage(uint damage)
    {
        uint coefficient;
        switch (damage)
        {
            case <= 1:
                coefficient = 5;
                break;
            case <= 5:
                coefficient = 4;
                break;
            default:
                coefficient = 100;
                break;
        }

        HealthPoints.Damage(damage * coefficient);
    }
}