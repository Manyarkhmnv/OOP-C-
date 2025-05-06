using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class Chipset : IName
{
    public Chipset(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public bool Equals(Chipset? obj)
    {
        return obj != null && this.Name.Equals(obj.Name, StringComparison.Ordinal);
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode(StringComparison.Ordinal);
    }
}