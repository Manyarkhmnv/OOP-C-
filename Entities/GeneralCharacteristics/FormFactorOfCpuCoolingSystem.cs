using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.FrameComponent;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class FormFactorOfCpuCoolingSystem : ICharacteristics
{
    public FormFactorOfCpuCoolingSystem(double lenghth, double weight, double height)
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
        return obj?.FormFactorsOfMotherboard != null && obj != null && this.Lenghth.Equals(obj.FormFactorsOfMotherboard.Lenghth) && this.Weight.Equals(obj.FormFactorsOfMotherboard.Weight) && this.Height.Equals(obj.FormFactorsOfMotherboard.Height);
    }

    public override int GetHashCode()
    {
        return this.Lenghth.GetHashCode();
    }
}