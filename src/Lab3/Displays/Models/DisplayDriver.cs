using System;
using System.Drawing;
using static Crayon.Output;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;

public class DisplayDriver : IDisplayDriver
{
    private Color _color;
    public void UpdateColor(Color color)
    {
        _color = color;
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void Input(string message)
    {
        Console.WriteLine(Rgb(_color.R, _color.G, _color.B).Text(message));
    }
}