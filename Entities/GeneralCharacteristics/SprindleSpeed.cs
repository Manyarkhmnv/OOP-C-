namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class SprindleSpeed : ICharacteristics
{
    public SprindleSpeed(int speed)
    {
        Numbers = speed;
    }

    public int Numbers { get; }

    public override int GetHashCode()
    {
        return this.Numbers.GetHashCode();
    }
}