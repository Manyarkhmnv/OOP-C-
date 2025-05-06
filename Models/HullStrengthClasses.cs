using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class HullStrengthClasses
{
    public abstract Result TakeDamage(IReadOnlyCollection<IObstacles> barrier);
}