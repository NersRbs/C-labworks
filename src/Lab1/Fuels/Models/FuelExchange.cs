using System;
using Itmo.ObjectOrientedProgramming.Lab1.Fuels.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Fuels.Models;

public abstract class FuelExchange
{
    public static Cost ActivePlasmaCost => 500;
    public static Cost GravitonMatterCost => 10000;

    public static Cost EvaluateCost(IFuel fuel)
    {
        switch (fuel)
        {
            case ActivePlasma:
                return fuel.СontainedFuel * ActivePlasmaCost;
            case GravitonMatter:
                return fuel.СontainedFuel * GravitonMatterCost;
            default:
                throw new ArgumentException("Unexpected case");
        }
    }
}