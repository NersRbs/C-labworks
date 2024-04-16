using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities.JumpEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities.PulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.PhotonicDeflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Stella : IShipWithJumpEngine
{
    public Stella(IPhotonicDeflector photonicDeflector)
    {
        PulseEngine = new PulseEngineC();
        JumpEngine = new OmegaEngine();
        CaseStrength = new CaseStrengthClass1();
        Deflector = new DeflectorClass1(photonicDeflector);
    }

    public Stella()
        : this(new NullPhotonicDeflector())
    {
    }

    public IPulseEngine PulseEngine { get; }
    public IJumpEngine JumpEngine { get; }
    public ICaseStrength CaseStrength { get; }
    public IDeflector Deflector { get; }

    public void TakeDamage(uint damage)
    {
        uint remainingDamage = Deflector.TakeDamage(damage);
        CaseStrength.TakeDamage(remainingDamage);
    }
}