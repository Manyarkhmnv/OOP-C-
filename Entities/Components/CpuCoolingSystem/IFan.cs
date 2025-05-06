using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuCoolingSystem;

public interface IFan
{
    public FormFactorOfCpuCoolingSystem? FormFactor { get; protected set; }
    public Socket? Socket { get; protected set; }
    public MaxTdp? MaxTdp { get; protected set; }
}