using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class PciE : IAmounts
{
    public PciE(int amountOfpciE)
    {
        Numbers = amountOfpciE;
    }

    public int Numbers { get; }

    public override int GetHashCode()
    {
        return this.Numbers.GetHashCode();
    }
}