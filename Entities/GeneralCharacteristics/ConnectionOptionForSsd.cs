using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class ConnectionOptionForSsd : IName
{
    public ConnectionOptionForSsd(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode(StringComparison.Ordinal);
    }
}