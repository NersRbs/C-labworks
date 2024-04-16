using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.WiFiAdapters.Entities;

public class WiFiAdapter : IWiFiAdapter
{
    public WiFiAdapter(
        string model,
        Version versionWiFiStandard,
        bool thePresenceBluetoothModule,
        Version versionPciE,
        int powerConsumption)
    {
        Model = model;
        VersionWiFiStandard = versionWiFiStandard;
        ThePresenceBluetoothModule = thePresenceBluetoothModule;
        VersionPciE = versionPciE;
        PowerConsumption = powerConsumption;
    }

    public string Model { get; }
    public Version VersionWiFiStandard { get; }
    public bool ThePresenceBluetoothModule { get; }
    public Version VersionPciE { get; }
    public int PowerConsumption { get; }

    public IWiFiAdapter Clone()
    {
        return new WiFiAdapter(
            Model,
            VersionWiFiStandard,
            ThePresenceBluetoothModule,
            VersionPciE,
            PowerConsumption);
    }
}