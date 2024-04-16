using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

public interface IObstacle
{
    void Attack(IShip ship);
}