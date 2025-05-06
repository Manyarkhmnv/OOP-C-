using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.HddComponent;

public class Hdd : IHdd
{
    internal Hdd(Capacity capacity, SprindleSpeed sprindleSpeed, PowerConsumption powerConsumption)
    {
        Capacity = capacity;
        SprindleSpeed = sprindleSpeed;
        PowerConsumption = powerConsumption;
    }

    public Capacity? Capacity { get; set; }
    public SprindleSpeed? SprindleSpeed { get; set; }
    public PowerConsumption? PowerConsumption { get; set; }
    public string? Name { get; set; }

    public class HddBuilder
    {
        private Capacity? _capacity;
        private SprindleSpeed? _sprindleSpeed;
        private PowerConsumption? _powerConsumption;
        public HddBuilder Add(Capacity capacity)
        {
            _capacity = capacity;
            return this;
        }

        public HddBuilder Add(SprindleSpeed sprindleSpeed)
        {
            _sprindleSpeed = sprindleSpeed;
            return this;
        }

        public HddBuilder Add(PowerConsumption powerConsumption)
        {
            _powerConsumption = powerConsumption;
            return this;
        }

        public Hdd Build()
        {
            if (_capacity != null)
            {
                if (_sprindleSpeed != null)
                {
                    if (_powerConsumption != null)
                    {
                        return new Hdd(_capacity, _sprindleSpeed, _powerConsumption);
                    }
                }
            }

            throw new System.NotImplementedException();
        }
    }
}