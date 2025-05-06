using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RamComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.VideoCardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PowerUnitComponent;

public interface IPowerUnit
{
    public PowerConsumption? PowerConsumption { get; protected set; }
    public bool Equals(Collection<IDrive> drives, IVideoCard? obj2, IRam? obj3, ICpu? obj4)
    {
        return PowerConsumption != null && PowerConsumption.Equals(drives, obj2, obj3, obj4);
    }
}