using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class NebulaeOfIncreasedDensity : Spaces

// туманности повышенной плотности
{
    internal NebulaeOfIncreasedDensity(int lenghthOfRoute, IReadOnlyCollection<IAntimatter> obstaclesList)
    {
        LenghthOfRoute = lenghthOfRoute;
        ObstaclesList = obstaclesList;
    }

    public override int LenghthOfRoute { get; }
    public override IReadOnlyCollection<IAntimatter> ObstaclesList { get; }
}