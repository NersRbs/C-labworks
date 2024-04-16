using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities.JumpEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface IShipWithJumpEngine : IShip
{
    IJumpEngine JumpEngine { get; }
}