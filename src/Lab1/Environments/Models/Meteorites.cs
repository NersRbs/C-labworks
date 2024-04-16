using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public class Meteorites : IObstacle
{
    private const uint Damage = 5;
    public void Attack(IShip ship)
    {
        ship.TakeDamage(Damage);
    }
}