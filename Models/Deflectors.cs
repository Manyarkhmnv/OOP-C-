using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1;
public abstract class Deflectors
{
    public abstract Result RepellingTheAttack(IReadOnlyCollection<IObstacles> barrier);
}