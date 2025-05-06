namespace Itmo.ObjectOrientedProgramming.Lab1;

public interface IObstacles
{
    public double DamageCoefficient { get; protected set; }
    public string ObstacleName { get;  }

    public void ChangeDamageCoefficient(double damageDecrement)
    {
        DamageCoefficient = DamageCoefficient - damageDecrement;
    }
}