using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponent;

public interface IMotherboard
{
    public Socket? Socket { get; protected set; }
    public PciE? PciE { get; protected set; }
    public SataPorts? SataPorts { get; protected set; }
    public Chipset? Chipset { get; protected set; }
    public StandardDdr? StandardDdr { get; protected set; }
    public TablesRam? TablesRam { get; protected set; }
    public FormFactorOfMotherboard? FormFactor { get; set; }

    public bool Equals(ICpu? obj);

    public bool Equals(Entities.Components.RamComponent.Ram obj);
}