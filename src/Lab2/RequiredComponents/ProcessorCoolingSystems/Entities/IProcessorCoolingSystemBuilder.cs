using System.Collections.Generic;
using Socket = Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.ProcessorCoolingSystems.Entities;

public interface IProcessorCoolingSystemBuilder
{
    IProcessorCoolingSystemBuilder SetModel(string model);
    IProcessorCoolingSystemBuilder SetDimensions(double dimensions);
    IProcessorCoolingSystemBuilder SetSupportedSockets(HashSet<Socket> supportedSockets);
    IProcessorCoolingSystemBuilder SetMaximumDissipatedHeatMass(int maximumDissipatedHeatMass);
    IProcessorCoolingSystem Build();
}