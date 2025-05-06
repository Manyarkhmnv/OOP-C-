namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class TablesRam : ICharacteristics
{
    public TablesRam(int amountOfTablesRam)
    {
        Numbers = amountOfTablesRam;
    }

    public int Numbers { get; }

    public override int GetHashCode()
    {
        return this.Numbers.GetHashCode();
    }
}