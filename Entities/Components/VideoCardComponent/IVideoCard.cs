using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.VideoCardComponent;

public interface IVideoCard
{
    public Dimensions? FormFactor { get; protected set; }
    public VideoMemory? AmountOfVideoMemory { get; protected set; }
    public PciE? AmountOfPciELines { get; protected set; }
    public ChipFrequency? ChipFrequency { get; protected set; }
    public PowerConsumption? PowerConsumption { get; protected set; }
}