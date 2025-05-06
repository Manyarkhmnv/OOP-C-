using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.FrameComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class FormFactorOfMotherboard : ICharacteristics
{
    public FormFactorOfMotherboard(double lenghth, double weight, double height)
    {
        Lenghth = lenghth;
        Weight = weight;
        Height = height;
    }

    public double Lenghth { get; }
    public double Weight { get; }
    public double Height { get; }

    public bool Equals(Frame? obj)
    {
        return obj?.FormFactorOfFrame != null && obj?.FormFactorsOfMotherboard != null && obj != null && this.Lenghth <= obj.FormFactorOfFrame.Lenghth && this.Weight <= obj.FormFactorOfFrame.Weight && this.Height <= obj.FormFactorOfFrame.Height;
    }

    public override int GetHashCode()
    {
        return this.Lenghth.GetHashCode();
    }
}