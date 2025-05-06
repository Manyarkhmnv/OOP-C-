using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class PleasureShuttle : Ship
{
    private const int Fuel = 30;
    private int _fuel;
    private ImpulseEngineC _engine;
    private StrengthClassOne _hull;
    private PhotonicDeflectors _photonicDeflectors;
    private AntiNitrineEmitter _antiNitrineEmitter;

    internal PleasureShuttle()
    {
        _engine = new ImpulseEngineC();
        _fuel = Fuel;
        _hull = new StrengthClassOne();
        _photonicDeflectors = new PhotonicDeflectors();
        _antiNitrineEmitter = new AntiNitrineEmitter();
    }

    public void AntinitrinesProtection(IReadOnlyCollection<IObstacles> stones)
    {
        _antiNitrineEmitter.RepellingTheAttack(stones);
    }

    public void PhotonicDamage(IReadOnlyCollection<IObstacles> stones)
    {
        _photonicDeflectors.RepellingTheAttack(stones);
    }

    public override Result GetDefDamage(Route route)
    {
        throw new System.NotImplementedException();
    }

    public override Result GetHullDamage(IReadOnlyCollection<IObstacles> stones)
    {
        return _hull.TakeDamage(stones);
    }

    public override Result Route(IList<Spaces> spaces)
    {
        IList<Engines> enginesList = new List<Engines>();
        enginesList.Add(_engine);
        Route route;
        route = new Route(spaces);
        return route.CountRoute(_fuel, enginesList);
    }
}