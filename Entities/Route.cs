using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Route
{
    private readonly IList<Spaces> _spaces;

    public Route(IList<Spaces> spaces)
    {
        _spaces = spaces;
    }

    public IReadOnlyCollection<IObstacles> ObstaclesCollection => _spaces.SelectMany(x => x.ObstaclesList).ToList();
    public Result CountRoute(int amountOfFuel, IList<Engines> enginesList)
    {
        int amountOfWastedFuel = 0;
        for (int i = 0; i < _spaces.Count; i++)
        {
            for (int j = 0; j < enginesList.Count; j++)
            {
                amountOfWastedFuel = enginesList[j].CalculationOfFuelAtSpeed(_spaces[i]) + amountOfWastedFuel;
            }
        }

        if (amountOfWastedFuel < amountOfFuel)
        {
            return Result.Success;
        }

        return Result.LossOfShip;
    }
}