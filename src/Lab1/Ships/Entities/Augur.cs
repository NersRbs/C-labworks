using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities.JumpEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities.PulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.PhotonicDeflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Augur : IShipWithJumpEngine
{
    public Augur(IPhotonicDeflector photonicDeflector)
    {
        PulseEngine = new PulseEngineE();
        JumpEngine = new AlphaEngine();
        CaseStrength = new CaseStrengthClass3();
        Deflector = new DeflectorClass3(photonicDeflector);
    }

    public Augur()
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