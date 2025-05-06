namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Antimatter : IAntimatter
{
    public Antimatter()
    {
        DamageCoefficient = 10000;
        ObstacleName = "Antimatter";
    }

    public double DamageCoefficient { get; set; }
    public string ObstacleName { get; set; }
}