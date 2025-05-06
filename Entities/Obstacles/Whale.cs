namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Whale : IWhale
{
    internal Whale()
    {
        DamageCoefficient = 1;
        ObstacleName = "Whale";
    }

    public double DamageCoefficient { get; set; }
    public string ObstacleName { get; set; }
}