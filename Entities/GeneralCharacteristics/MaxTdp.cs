using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class MaxTdp : IAmounts
{
    public MaxTdp(int maxtdp)
    {
        Numbers = maxtdp;
    }

    public int Numbers { get; }
    public bool Equals(Cpu? obj)
    {
        return obj?.Tdp != null && obj != null && this.Numbers >= obj.Tdp.Numbers;
    }

    public override int GetHashCode()
    {
        return this.Numbers.GetHashCode();
    }
}