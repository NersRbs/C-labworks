using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.CentralProcessingUnits.Entities;

public interface ICentralProcessingUnitBuilder
{
    ICentralProcessingUnitBuilder SetModel(string model);
    ICentralProcessingUnitBuilder SetCoreFrequency(double coreFrequency);
    ICentralProcessingUnitBuilder SetCountOfCores(int countOfCores);
    ICentralProcessingUnitBuilder SetSocket(Socket socket);
    ICentralProcessingUnitBuilder SetPresenceBuiltInVideoCore(bool presenceBuiltInVideoCore);
    ICentralProcessingUnitBuilder SetSupportedMemoryFrequencies(HashSet<double> supportedMemoryFrequencies);
    ICentralProcessingUnitBuilder SetHeatDissipation(int heatDissipation);
    ICentralProcessingUnitBuilder SetPowerConsumption(int powerConsumption);
    ICentralProcessingUnit Build();
}