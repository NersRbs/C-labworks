using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public class NebulaeOfIncreasedDensityOfSpace : IEnvironment
{
    private IList<INebulaeOfIncreasedDensityOfSpaceObstacle> _obstacles;
    public NebulaeOfIncreasedDensityOfSpace(IList<INebulaeOfIncreasedDensityOfSpaceObstacle> obstacles)
    {
        _obstacles = obstacles;
    }

    public void Attack(IShip ship)
    {
        foreach (INebulaeOfIncreasedDensityOfSpaceObstacle obstacle in _obstacles)
        {
            obstacle.Attack(ship);
        }
    }

    public bool ShipCanPass(double distance, IShip ship)
    {
        if (ship is IShipWithJumpEngine shipWithJumpEngine &&
            shipWithJumpEngine.JumpEngine.CanOvercome(distance))
        {
            return true;
        }

        return false;
    }

    public TimeAndFuel? GetTimeAndFuel(double distance, IShip ship)
    {
        if (ShipCanPass(distance, ship))
        {
            var shipWithJumpEngine = ship as IShipWithJumpEngine;
            return shipWithJumpEngine?.JumpEngine.Calculate(distance);
        }

        return null;
    }
}
