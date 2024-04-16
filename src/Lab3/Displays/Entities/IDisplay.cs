using Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;

public interface IDisplay
{
    IDisplayDriver DisplayDriver { get; }
    void Input(string message);
}