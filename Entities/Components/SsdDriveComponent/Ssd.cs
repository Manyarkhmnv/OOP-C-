using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SsdDriveComponent;

public class Ssd : ISsdDrive
{
    internal Ssd(ConnectionOptionForSsd connectionOption, Capacity capacity, SpeedOfWork speedOfWork, PowerConsumption powerConsumption)
    {
        ConnectionOption = connectionOption;
        Capacity = capacity;
        SpeedOfWork = speedOfWork;
        PowerConsumption = powerConsumption;
    }

    public static SsdBuilder Builder => new SsdBuilder();
    public ConnectionOptionForSsd? ConnectionOption { get; set; }
    public Capacity? Capacity { get; set; }
    public SpeedOfWork? SpeedOfWork { get; set; }
    public PowerConsumption? PowerConsumption { get; set; }
    public string? Name { get; set; }

    public class SsdBuilder
    {
        private ConnectionOptionForSsd? _connectionOption;
        private Capacity? _capacity;
        private SpeedOfWork? _speedOfWork;
        private PowerConsumption? _powerConsumption;
        public SsdBuilder Add(ConnectionOptionForSsd connectionOption)
        {
            _connectionOption = connectionOption;
            return this;
        }

        public SsdBuilder Add(Capacity capacity)
        {
            _capacity = capacity;
            return this;
        }

        public SsdBuilder Add(SpeedOfWork speedOfWork)
        {
            _speedOfWork = speedOfWork;
            return this;
        }

        public SsdBuilder Add(PowerConsumption powerConsumption)
        {
            _powerConsumption = powerConsumption;
            return this;
        }

        public Ssd Build()
        {
                if (_speedOfWork != null)
                {
                    if (_capacity != null)
                    {
                        if (_connectionOption != null)
                        {
                            if (_powerConsumption != null)
                            {
                                return new Ssd(_connectionOption, _capacity, _speedOfWork, _powerConsumption);
                            }
                        }
                    }
                }

                throw new System.NotImplementedException();
        }
    }
}