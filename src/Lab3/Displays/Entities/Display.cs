using Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;

public class Display : IDisplay
{
    public Display(IDisplayDriver displayDriver)
    {
        DisplayDriver = displayDriver;
    }

    public IDisplayDriver DisplayDriver { get; }
    public void Input(string message)
    {
        DisplayDriver.Clear();
        DisplayDriver.Input(message);
    }
}