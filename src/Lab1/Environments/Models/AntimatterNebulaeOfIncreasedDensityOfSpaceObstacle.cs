using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class AntimatterNebulaeOfIncreasedDensityOfSpaceObstacle : INebulaeOfIncreasedDensityOfSpaceObstacle
{
    private const uint Damage = 1;

    public void Attack(IShip ship)
    {
        ship.Deflector.PhotonicDeflector.HealthPoints.Damage(Damage);
    }
}