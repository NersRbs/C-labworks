using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public interface IEnvironment
{
    public void Attack(IShip ship);

    bool ShipCanPass(double distance, IShip ship);

    TimeAndFuel? GetTimeAndFuel(double distance, IShip ship);
}