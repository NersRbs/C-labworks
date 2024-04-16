using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Fuels.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route.Entities;

public class Route
{
    private List<Segment> _segments;

    public Route(params Segment[] segment)
    {
        if (segment == null)
        {
            throw new ArgumentNullException(nameof(segment));
        }

        _segments = new List<Segment>();
        foreach (Segment value in segment)
        {
            _segments.Add(value);
        }
    }

    public IList<Status> Check(params IShip[] ships)
    {
        var resultStatus = new List<Status>();
        foreach (IShip ship in ships)
        {
            Status status;
            Time time = 0;
            Cost cost = 0;
            bool flagPassed = true;

            foreach (Segment segment in _segments)
            {
                status = segment.Pass(ship);

                if (status is Status.Success success)
                {
                    time += success.Time;
                    cost += success.Cost;
                }
                else
                {
                    resultStatus.Add(status);
                    flagPassed = false;
                    break;
                }
            }

            if (flagPassed)
            {
                resultStatus.Add(new Status.Success(time, cost));
            }
        }

        return resultStatus;
    }

    public IShip? Optimal(params IShip[] ships)
    {
        IShip? result = null;
        Cost cost = 0;
        foreach (IShip ship in ships)
        {
            Status status = Check(ship).First();
            if (status is Status.Success value && (result is null || (cost.Data > value.Cost.Data)))
            {
                result = ship;
                cost = value.Cost;
            }
        }

        return result;
    }
}