using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Meredian : Ship
{
    private const int Fuel = 30;
    private int _fuel;
    private StrengthClassTwo _hull;
    private ImpulseEngineE _engine;
    private DeflectorClassTwo _deflector;
    private PhotonicDeflectors _photonicDeflectors;
    private AntiNitrineEmitter _antiNitrineEmitter;

    internal Meredian()
    {
    _hull = new StrengthClassTwo();
    _engine = new ImpulseEngineE();
    _deflector = new DeflectorClassTwo();
    _photonicDeflectors = new PhotonicDeflectors();
    _antiNitrineEmitter = new AntiNitrineEmitter();
    _fuel = Fuel;
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
        IReadOnlyCollection<IObstacles> stones = route.ObstaclesCollection;
        Result result = _deflector.RepellingTheAttack(stones);
        if (result == Result.DeathOfTheCrew)
        {
            return GetHullDamage(stones);
        }

        return result;
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