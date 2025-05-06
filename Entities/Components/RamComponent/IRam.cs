using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RamComponent;

public interface IRam
{
    public Memory? Memory { get; protected set; }
    public ChipFrequency? Frequency { get; protected set; }
    public FormFactorOfRam? FormFactor { get; protected set; }
    public StandardDdr? StandardDdr { get; protected set; }
    public PowerConsumption? PowerConsumption { get; protected set; }
}