using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities.PulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface IShip
{
    IPulseEngine PulseEngine { get; }
    ICaseStrength CaseStrength { get; }
    IDeflector Deflector { get; }

    void TakeDamage(uint damage);
}