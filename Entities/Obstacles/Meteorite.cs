namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Meteorite : IStones
{
    internal Meteorite()
    {
        DamageCoefficient = 0.2;
        ObstacleName = "Meteorite";
    }

    public double DamageCoefficient { get; set; }
    public string ObstacleName { get; set; }
}