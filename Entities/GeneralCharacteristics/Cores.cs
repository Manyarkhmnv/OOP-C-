namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class Cores
{
    public Cores(int amountOfCores)
    {
        Numbers = amountOfCores;
    }

    public int Numbers { get; }

    public override int GetHashCode()
    {
        return this.Numbers.GetHashCode();
    }
}