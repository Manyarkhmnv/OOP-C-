using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class DeflectorClassThree : Deflectors
{
    private double _healthDef = 50;

    public override Result RepellingTheAttack(IReadOnlyCollection<IObstacles> barrier)
    {
        foreach (IObstacles obstacles in barrier)
        {
            obstacles.ChangeDamageCoefficient(0.5);
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