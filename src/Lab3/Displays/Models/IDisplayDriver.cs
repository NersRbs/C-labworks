using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Models;

public interface IDisplayDriver
{
    void UpdateColor(Color color);
    void Clear();
    void Input(string message);
}