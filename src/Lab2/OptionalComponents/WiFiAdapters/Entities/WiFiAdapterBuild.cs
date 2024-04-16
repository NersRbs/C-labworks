using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.OptionalComponents.WiFiAdapters.Entities;

public class WiFiAdapterBuild : IWiFiAdapterBuild
{
    private string? _model;
    private Version? _versionWiFiStandard;
    private bool? _thePresenceBluetoothModule;
    private Version? _versionPciE;
    private int? _powerConsumption;

    public IWiFiAdapterBuild SetModel(string model)
    {
        _model = model;
        return this;
    }

    public IWiFiAdapterBuild SetVersionWiFiStandard(Version versionWiFiStandard)
    {
        _versionWiFiStandard = versionWiFiStandard;
        return this;
    }

    public IWiFiAdapterBuild SetThePresenceBluetoothModule(bool thePresenceBluetoothModule)
    {
        _thePresenceBluetoothModule = thePresenceBluetoothModule;
        return this;
    }

    public IWiFiAdapterBuild SetVersionPciE(Version versionPciE)
    {
        _versionPciE = versionPciE;
        return this;
    }

    public IWiFiAdapterBuild SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IWiFiAdapter Build()
    {
        if (_model is null ||
            _versionWiFiStandard is null ||
            _thePresenceBluetoothModule is null ||
            _versionPciE is null ||
            _powerConsumption is null)
        {
            throw new InvalidOperationException("Not all fields are filled");
        }

        return new WiFiAdapter(
            _model,
            _versionWiFiStandard,
            _thePresenceBluetoothModule.Value,
            _versionPciE,
            _powerConsumption.Value);
    }
}