using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities.PulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class PleasureShuttle : IShip
{
    public IPulseEngine PulseEngine { get; } = new PulseEngineC();
    public ICaseStrength CaseStrength { get; } = new CaseStrengthClass1();
    public IDeflector Deflector { get; } = new NullDeflector();
    public void TakeDamage(uint damage)
    {
        uint remainingDamage = Deflector.TakeDamage(damage);
        CaseStrength.TakeDamage(remainingDamage);
    }
}