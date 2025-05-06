using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class Ship
{
    public abstract Result GetDefDamage(Route route);

    public abstract Result GetHullDamage(IReadOnlyCollection<IObstacles> stones);

    public abstract Result Route(IList<Spaces> spaces);
}