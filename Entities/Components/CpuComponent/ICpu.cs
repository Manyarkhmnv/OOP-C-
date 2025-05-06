using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuComponent;

public interface ICpu
{
    public Cores? AmountOfCores { get; protected set; }
    public Socket? Socket { get; protected set; }
    public PresenceOfVideoCore? PresenceOfVideoCore { get; protected set; }
    public CoreFrequency? Frequency { get; protected set; }
    public MaxTdp? Tdp { get; protected set; }
    public PowerConsumption? PowerConsumption { get; protected set; }
}