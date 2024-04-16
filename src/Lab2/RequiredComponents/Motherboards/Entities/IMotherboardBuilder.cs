using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.Chipset;

namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Entities;

public interface IMotherboardBuilder
{
    IMotherboardBuilder SetModel(string model);
    IMotherboardBuilder SetSocket(Socket socket);
    IMotherboardBuilder SetCountOfLinesSolderedPciE(int countOfLinesSolderedPciE);
    IMotherboardBuilder SetCountOfPortsSolderedSata(int countOfPortsSolderedSata);
    IMotherboardBuilder SetChipset(IChipset chipset);
    IMotherboardBuilder SetSupportedDdrStandard(Ddr supportedDdrStandard);
    IMotherboardBuilder SetCountOfTablesUnderRam(int countOfTablesUnderRam);
    IMotherboardBuilder SetFormFactor(FormFactor formFactor);
    IMotherboardBuilder SetBios(IBios bios);
    IMotherboard Build();
}