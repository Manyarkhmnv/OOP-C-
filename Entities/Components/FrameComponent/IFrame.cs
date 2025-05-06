using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.FrameComponent;

public interface IFrame
{
    public FormFactorOfMotherboard? FormFactorsOfMotherboard { get; protected set; }
    public Dimensions? FormFactorOfVideocard { get; protected set; }
    public FormFactorOfFrame? FormFactorOfFrame { get; protected set; }
    public bool Equals(VideoCardComponent.VideoCard obj)
    {
        Dimensions? dimensions = this.FormFactorOfVideocard;
        return dimensions != null && obj != null && (obj.FormFactor != null) && obj.FormFactor.Equals(obj);
    }

    public bool Equals(Motherboard obj)
    {
        return obj != null && (obj.FormFactor != null) && obj.FormFactor.Equals(this);
    }
}