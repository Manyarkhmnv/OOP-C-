using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class DeflectorClassTwo : Deflectors
{
    private double _healthDef = 40;

    public override Result RepellingTheAttack(IReadOnlyCollection<IObstacles> barrier)
    {
        foreach (IObstacles obstacles in barrier)
        {
            _healthDef -= obstacles.DamageCoefficient * _healthDef;
            obstacles.ChangeDamageCoefficient(0.2);
        }

        if (_healthDef < 0)
        {
            return Result.DeathOfTheCrew;
        }

        if (_healthDef == 0)
        {
            return Result.DestructionOfTheShip;
        }

        return Result.Success;
    }
}