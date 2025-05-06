using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Augur : Ship
{
    private const int Fuel = 30;
    private int _fuel;
    private ImpulseEngineE _engine;
    private ImpulseEngineE _jumpEngine;
    private StrengthClassThree _hull;
    private DeflectorClassThree _deflector;
    private PhotonicDeflectors _photonicDeflectors;
    private AntiNitrineEmitter _antiNitrineEmitter;

    internal Augur()
    {
        _engine = new ImpulseEngineE();
        _jumpEngine = new ImpulseEngineE();
        _hull = new StrengthClassThree();
        _deflector = new DeflectorClassThree();
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
        enginesList.Add(_jumpEngine);
        enginesList.Add(_engine);
        Route route;
        route = new Route(spaces);
        return route.CountRoute(_fuel, enginesList);
    }
}
