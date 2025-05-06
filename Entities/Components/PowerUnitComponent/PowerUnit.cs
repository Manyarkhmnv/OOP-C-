using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RamComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.VideoCardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PowerUnitComponent;

public class PowerUnit : IPowerUnit
{
    internal PowerUnit(PowerConsumption powerConsumption)
    {
        PowerConsumption = powerConsumption;
    }

    public static PowerUnitBuilder Builder => new PowerUnitBuilder();
    public PowerConsumption? PowerConsumption { get; set; }
    public bool Equals(Collection<IDrive> drives, IVideoCard? obj2, IRam? obj3, ICpu? obj4)
    {
        return PowerConsumption != null && PowerConsumption.Equals(drives, obj2, obj3, obj4);
    }

    public class PowerUnitBuilder
    {
        private PowerConsumption? _powerConsumption;

        public PowerUnitBuilder Add(PowerConsumption powerConsumption)
        {
            _powerConsumption = powerConsumption;
            return this;
        }

        public PowerUnit Build()
        {
            if (_powerConsumption != null)
            {
                return new PowerUnit(_powerConsumption);
            }

            throw new System.NotImplementedException();
        }
    }
}