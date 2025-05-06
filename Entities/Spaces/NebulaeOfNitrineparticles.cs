using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class NebulaeOfNitrineparticles : Spaces
{
    // туманности нитринных частиц:
    internal NebulaeOfNitrineparticles(int lenghthOfRoute, IReadOnlyCollection<IWhale> obstaclesList)
    {
        LenghthOfRoute = lenghthOfRoute;
        ObstaclesList = obstaclesList;
    }

    public override int LenghthOfRoute { get; }
    public override IReadOnlyCollection<IWhale> ObstaclesList { get; }
}