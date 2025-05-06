using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class Spaces
{
    public abstract int LenghthOfRoute { get; }
    public abstract IReadOnlyCollection<IObstacles> ObstaclesList { get; }
}