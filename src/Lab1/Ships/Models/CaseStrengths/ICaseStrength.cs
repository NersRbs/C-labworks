namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.CaseStrengths;

public interface ICaseStrength
{
    HealthPoints HealthPoints { get; }

    uint GetCoefficient(uint damage);

    void TakeDamage(uint damage);
}