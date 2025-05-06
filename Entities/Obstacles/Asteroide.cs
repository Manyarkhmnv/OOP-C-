namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Asteroide : IStones
{
    internal Asteroide()
    {
        DamageCoefficient = 0.2;
        ObstacleName = "Asteroide";
    }

    public double DamageCoefficient { get; set; } = 0.2;
    public string ObstacleName { get; set; }
}