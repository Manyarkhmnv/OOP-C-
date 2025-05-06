using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class Capacity : IAmounts
{
    public Capacity(int capacity)
    {
        Numbers = capacity;
    }

    public int Numbers { get; }

    public override int GetHashCode()
    {
        return this.Numbers.GetHashCode();
    }
}