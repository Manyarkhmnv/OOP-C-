using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class StandardDdr : IName
{
    public StandardDdr(string standardDdrName)
    {
        Name = standardDdrName;
    }

    public string Name { get; }

    public bool Equals(StandardDdr? obj)
    {
        return obj != null && this.Name.Equals(obj.Name, System.StringComparison.Ordinal);
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode(StringComparison.Ordinal);
    }
}