using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class CosmoWhales : INebulaeOfNitrideParticlesObstacle
{
    private const uint Damage = 10;
    public void Attack(IShip ship)
    {
        if (ship is not IShipWithAntineutrineEmitter)
        {
            ship.TakeDamage(Damage);
        }
    }
}