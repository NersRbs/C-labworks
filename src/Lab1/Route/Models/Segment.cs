using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Fuels.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route.Models;

public class Segment
{
    public Segment(double distance, IEnvironment environment)
    {
        Distance = distance;
        Environment = environment;
    }

    public double Distance { get; }
    public IEnvironment Environment { get; }

    public bool ShipCanPass(IShip ship)
    {
        return Environment.ShipCanPass(Distance, ship);
    }

    public Status Pass(IShip ship)
    {
        Environment.Attack(ship);

        if (ship.CaseStrength.HealthPoints.Health == 0)
        {
            return new Status.DestructionOfTheShip();
        }

        if (ship.Deflector.PhotonicDeflector.HealthPoints.Health == 0)
        {
            return new Status.DeathOfTheCrew();
        }

        TimeAndFuel? timeAndFuel = Environment.GetTimeAndFuel(Distance, ship);
        if (timeAndFuel is null)
        {
            return new Status.LossOfTheShip();
        }

        return new Status.Success(timeAndFuel.Time, FuelExchange.EvaluateCost(timeAndFuel.Fuel));
    }
}