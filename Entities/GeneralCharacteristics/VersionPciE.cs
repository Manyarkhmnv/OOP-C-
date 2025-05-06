namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class VersionPciE : ICharacteristics
{
    public VersionPciE(int versionPciE)
    {
        Numbers = versionPciE;
    }

    public int Numbers { get; }

    public override int GetHashCode()
    {
        return this.Numbers.GetHashCode();
    }
}