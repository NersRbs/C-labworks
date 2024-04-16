using System;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.Chipset;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Entities;

public class MotherboardBuilder : IMotherboardBuilder
{
    private string? _model;
    private Socket? _socket;
    private int? _countOfLinesSolderedPciE;
    private int? _countOfPortsSolderedSata;
    private IChipset? _chipset;
    private Ddr? _supportedDdrStandard;
    private int? _countOfTablesUnderRam;
    private FormFactor? _formFactor;
    private IBios? _bios;
    public IMotherboardBuilder SetModel(string model)
    {
        _model = model;
        return this;
    }

    public IMotherboardBuilder SetSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public IMotherboardBuilder SetCountOfLinesSolderedPciE(int countOfLinesSolderedPciE)
    {
        _countOfLinesSolderedPciE = countOfLinesSolderedPciE;
        return this;
    }

    public IMotherboardBuilder SetCountOfPortsSolderedSata(int countOfPortsSolderedSata)
    {
        _countOfPortsSolderedSata = countOfPortsSolderedSata;
        return this;
    }

    public IMotherboardBuilder SetChipset(IChipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherboardBuilder SetSupportedDdrStandard(Ddr supportedDdrStandard)
    {
        _supportedDdrStandard = supportedDdrStandard;
        return this;
    }

    public IMotherboardBuilder SetCountOfTablesUnderRam(int countOfTablesUnderRam)
    {
        _countOfTablesUnderRam = countOfTablesUnderRam;
        return this;
    }

    public IMotherboardBuilder SetFormFactor(FormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder SetBios(IBios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherboard Build()
    {
        if (_model is null ||
            _socket is null ||
            _countOfLinesSolderedPciE is null ||
            _countOfPortsSolderedSata is null ||
            _chipset is null ||
            _supportedDdrStandard is null ||
            _countOfTablesUnderRam is null ||
            _formFactor is null ||
            _bios is null)
        {
            throw new InvalidOperationException("Not all properties are set");
        }

        return new Motherboard(
            _model,
            _socket.Value,
            _countOfLinesSolderedPciE.Value,
            _countOfPortsSolderedSata.Value,
            _chipset.Clone(),
            _supportedDdrStandard.Value,
            _countOfTablesUnderRam.Value,
            _formFactor.Value,
            _bios.Clone());
    }
}