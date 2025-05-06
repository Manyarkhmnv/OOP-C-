using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class PhotonicDeflectors : Deflectors
{
    private double _healthDef = 10;
    private int invisibility;
    public override Result RepellingTheAttack(IReadOnlyCollection<IObstacles> barrier)
    {
        invisibility = 10000;
        foreach (IObstacles obstacles in barrier)
        {
            if (obstacles.ObstacleName == "Antimatter")
            {
                _healthDef -= obstacles.DamageCoefficient * _healthDef * 0.00003;
                obstacles.ChangeDamageCoefficient(invisibility);
            }
        }

        if (_healthDef <= 0)
        {
            return Result.DeathOfTheCrew;
        }

        return Result.Success;
    }
}