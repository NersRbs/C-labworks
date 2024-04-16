using System;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.Chipset;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Entities;

public class Motherboard : IMotherboard
{
    public Motherboard(
        string model,
        Socket socket,
        int countOfLinesSolderedPciE,
        int countOfPortsSolderedSata,
        IChipset chipset,
        Ddr supportedDdrStandard,
        int countOfTablesUnderRam,
        FormFactor formFactor,
        IBios bios)
    {
        if (countOfLinesSolderedPciE < 0)
        {
            throw new ArgumentException("Count of lines soldered PCI-E must be positive");
        }

        if (countOfPortsSolderedSata < 0)
        {
            throw new ArgumentException("Count of ports soldered SATA must be positive");
        }

        if (countOfTablesUnderRam < 0)
        {
            throw new ArgumentException("Count of tables under RAM must be positive");
        }

        Model = model;
        Socket = socket;
        CountOfLinesSolderedPciE = countOfLinesSolderedPciE;
        CountOfPortsSolderedSata = countOfPortsSolderedSata;
        Chipset = chipset;
        SupportedDdrStandard = supportedDdrStandard;
        CountOfTablesUnderRam = countOfTablesUnderRam;
        FormFactor = formFactor;
        Bios = bios;
    }

    public string Model { get; }

    public Socket Socket { get; }

    public int CountOfLinesSolderedPciE { get; }

    public int CountOfPortsSolderedSata { get; }

    public IChipset Chipset { get; }

    public Ddr SupportedDdrStandard { get; }

    public int CountOfTablesUnderRam { get; }

    public FormFactor FormFactor { get; }

    public IBios Bios { get; }

    public IMotherboard Clone()
    {
        return new Motherboard(
            Model,
            Socket,
            CountOfLinesSolderedPciE,
            CountOfPortsSolderedSata,
            Chipset.Clone(),
            SupportedDdrStandard,
            CountOfTablesUnderRam,
            FormFactor,
            Bios.Clone());
    }
}