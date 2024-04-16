namespace Itmo.ObjectOrientedProgramming.Lab2.RequiredComponents.Motherboards.Models.BIOS;

public abstract record BiosType()
{
    public sealed record ROM() : BiosType;

    public sealed record PROM() : BiosType;

    public sealed record EPROM() : BiosType;

    public sealed record EEPROM() : BiosType;
}