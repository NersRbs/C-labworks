using System;
using Itmo.ObjectOrientedProgramming.Lab2.AuxiliaryInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.WiFiAdapters.Entities;

public interface IWiFiAdapter : IModel, IPrototype<IWiFiAdapter>
{
    Version VersionWiFiStandard { get; }
    bool ThePresenceBluetoothModule { get; }
    Version VersionPciE { get; }
    int PowerConsumption { get; }
}