using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.WiFiAdapters.Entities;

public interface IWiFiAdapterBuild
{
    IWiFiAdapterBuild SetModel(string model);

    IWiFiAdapterBuild SetVersionWiFiStandard(Version versionWiFiStandard);
    IWiFiAdapterBuild SetThePresenceBluetoothModule(bool thePresenceBluetoothModule);
    IWiFiAdapterBuild SetVersionPciE(Version versionPciE);
    IWiFiAdapterBuild SetPowerConsumption(int powerConsumption);
    IWiFiAdapter Build();
}