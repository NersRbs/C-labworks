using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public class OrdinarySpace : IEnvironment
{
    private IList<IOrdinarySpaceObstacle> _obstacles;
    public OrdinarySpace(IList<IOrdinarySpaceObstacle> obstacles)
    {
        _obstacles = obstacles;
    }

    public void Attack(IShip ship)
    {
        foreach (IOrdinarySpaceObstacle obstacle in _obstacles)
        {
            obstacle.Attack(ship);
        }
    }

    public bool ShipCanPass(double distance, IShip ship)
    {
        return true;
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