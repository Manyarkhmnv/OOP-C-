namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class VideoMemory : ICharacteristics
{
    public VideoMemory(int videoMemory)
    {
        Numbers = videoMemory;
    }

    public int Numbers { get; }

    public override int GetHashCode()
    {
        return this.Numbers.GetHashCode();
    }
}