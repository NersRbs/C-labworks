using System;
using Itmo.ObjectOrientedProgramming.Lab1.Fuels.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;

public record EngineResult(TimeSpan Time, IFuel Fuel);