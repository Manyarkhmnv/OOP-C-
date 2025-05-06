using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1;
public class DeflectorClassOne : Deflectors
{
    private double _healthDef = 30;

    public override Result RepellingTheAttack(IReadOnlyCollection<IObstacles> barrier)
    {
        foreach (IObstacles obstacles in barrier)
        {
            _healthDef -= obstacles.DamageCoefficient * _healthDef;
            obstacles.ChangeDamageCoefficient(1.1);
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