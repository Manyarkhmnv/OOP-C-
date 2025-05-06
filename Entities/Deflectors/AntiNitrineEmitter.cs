using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class AntiNitrineEmitter : Deflectors
{
    public override Result RepellingTheAttack(IReadOnlyCollection<IObstacles> barrier)
    {
        foreach (IObstacles obstacles in barrier)
        {
            if (obstacles.ObstacleName == "Whale")
            {
                obstacles.ChangeDamageCoefficient(10000);
            }
        }

        return Result.Success;
    }
}