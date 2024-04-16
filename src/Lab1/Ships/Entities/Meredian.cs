using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities.PulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.CaseStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.PhotonicDeflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Meredian : IShip, IShipWithAntineutrineEmitter
{
    public Meredian(IPhotonicDeflector photonicDeflector)
    {
        PulseEngine = new PulseEngineE();
        CaseStrength = new CaseStrengthClass2();
        Deflector = new DeflectorClass2(photonicDeflector);
    }

    public Meredian()
        : this(new NullPhotonicDeflector())
    {
    }

    public IPulseEngine PulseEngine { get; }
    public ICaseStrength CaseStrength { get; }
    public IDeflector Deflector { get; }
    public void TakeDamage(uint damage)
    {
        uint remainingDamage = Deflector.TakeDamage(damage);
        CaseStrength.TakeDamage(remainingDamage);
    }
}