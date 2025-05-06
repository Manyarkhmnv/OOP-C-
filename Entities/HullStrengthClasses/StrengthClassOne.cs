using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class StrengthClassOne : HullStrengthClasses
{
    private double _healthHull = 2;

    public override Result TakeDamage(IReadOnlyCollection<IObstacles> barrier)
    {
        foreach (IObstacles obstacles in barrier)
        {
            _healthHull -= obstacles.DamageCoefficient * _healthHull;
            obstacles.ChangeDamageCoefficient(0.2);
        }

        if (_healthHull < 0)
        {
            return Result.DeathOfTheCrew;
        }

        if (_healthHull == 0)
        {
            return Result.DestructionOfTheShip;
        }

        return Result.Success;
    }
}