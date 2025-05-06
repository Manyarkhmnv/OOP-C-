namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class SataPorts : ICharacteristics
{
    public SataPorts(int powerConsumption)
    {
        Numbers = powerConsumption;
    }

    public int Numbers { get; }

    public override int GetHashCode()
    {
        return this.Numbers.GetHashCode();
    }
}