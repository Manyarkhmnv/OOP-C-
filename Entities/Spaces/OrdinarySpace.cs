using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class OrdinarySpace : Spaces
{
    internal OrdinarySpace(int lenghthOfRoute, IReadOnlyCollection<IStones> obstaclesList)
    {
        LenghthOfRoute = lenghthOfRoute;
        ObstaclesList = obstaclesList;
    }

    public override int LenghthOfRoute { get; }
    public override IReadOnlyCollection<IStones> ObstaclesList { get; }
}