using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities.PulseEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public class NebulaeOfNitrideParticles : IEnvironment
{
    private IList<INebulaeOfNitrideParticlesObstacle> _obstacles;
    public NebulaeOfNitrideParticles(IList<INebulaeOfNitrideParticlesObstacle> obstacles)
    {
        _obstacles = obstacles;
    }

    public void Attack(IShip ship)
    {
        foreach (INebulaeOfNitrideParticlesObstacle obstacle in _obstacles)
        {
            obstacle.Attack(ship);
        }
    }

    public bool ShipCanPass(double distance, IShip ship)
    {
        switch (ship.PulseEngine)
        {
            case PulseEngineC: return false;
            case PulseEngineE: return true;
            default: throw new InvalidOperationException("Unexpected case");
        }
    }

    public TimeAndFuel? GetTimeAndFuel(double distance, IShip ship)
    {
        if (ShipCanPass(distance, ship))
        {
            return ship.PulseEngine.Calculate(distance);
        }

        return null;
    }
}