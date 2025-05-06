using System.Collections.ObjectModel;
using System.Diagnostics;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RamComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.VideoCardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class PowerConsumption : IAmounts
{
    public PowerConsumption(int powerConsumption)
    {
        Numbers = powerConsumption;
    }

    public int Numbers { get; }

    public bool Equals(Collection<IDrive> drives, IVideoCard? obj2, IRam? obj3, ICpu? obj4)
    {
        int result = 0;
        Debug.Assert(drives != null, nameof(drives) + " != null");
        for (int i = 0; i < drives.Count; i++)
        {
            PowerConsumption? powerConsumption = drives[i].PowerConsumption;
            if (powerConsumption != null) result += powerConsumption.Numbers;
        }

        return obj4?.PowerConsumption != null && obj3?.PowerConsumption != null && obj2?.PowerConsumption != null && (result + obj2.PowerConsumption.Numbers + obj3.PowerConsumption.Numbers + obj4.PowerConsumption.Numbers) < this.Numbers;
    }

    public override int GetHashCode()
    {
        return this.Numbers.GetHashCode();
    }
}