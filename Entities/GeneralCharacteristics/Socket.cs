using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuCoolingSystem;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class Socket : ICharacteristics
{
    public Socket(string socketName)
    {
        Name = socketName;
    }

    public string Name { get; }

    public bool Equals(ICpu? obj)
    {
        return obj != null && this.Name.Equals(obj.Socket?.Name, System.StringComparison.Ordinal);
    }

    public bool Equals(IFan? obj)
    {
        return obj != null && this.Name.Equals(obj.Socket?.Name, System.StringComparison.Ordinal);
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode(StringComparison.Ordinal);
    }
}