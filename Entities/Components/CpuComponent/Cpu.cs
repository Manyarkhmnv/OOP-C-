using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuComponent;

public class Cpu : ICpu
{
    internal Cpu(Cores amountOfCores, Socket socket, PresenceOfVideoCore? presenceOfVideoCore, CoreFrequency frequency, MaxTdp tdp, PowerConsumption powerConsumption)
    {
        AmountOfCores = amountOfCores;
        Socket = socket;
        PresenceOfVideoCore = presenceOfVideoCore;
        Frequency = frequency;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public static CpuBuilder Builder => new CpuBuilder();
    public Cores? AmountOfCores { get; set; }
    public Socket? Socket { get; set; }
    public PresenceOfVideoCore? PresenceOfVideoCore { get; set; }
    public CoreFrequency? Frequency { get; set; }
    public MaxTdp? Tdp { get; set; }
    public PowerConsumption? PowerConsumption { get; set; }

    public class CpuBuilder
    {
        private Cores? _amountOfCores;
        private Socket? _socket;
        private PresenceOfVideoCore? _presenceOfVideoCore;
        private CoreFrequency? _frequency;
        private MaxTdp? _tdp;
        private PowerConsumption? _powerConsumption;

        public CpuBuilder Add(Cores amountOfCores)
        {
            _amountOfCores = amountOfCores;
            return this;
        }

        public CpuBuilder Add(Socket socket)
        {
            _socket = socket;
            return this;
        }

        public CpuBuilder Add(PresenceOfVideoCore presenceOfVideoCore)
        {
            _presenceOfVideoCore = presenceOfVideoCore;
            return this;
        }

        public CpuBuilder Add(CoreFrequency frequency)
        {
            _frequency = frequency;
            return this;
        }

        public CpuBuilder Add(MaxTdp tdp)
        {
            _tdp = tdp;
            return this;
        }

        public CpuBuilder Add(PowerConsumption powerConsumption)
        {
            _powerConsumption = powerConsumption;
            return this;
        }

        public Cpu Build()
        {
                if (_amountOfCores != null)
                {
                    if (_socket != null)
                    {
                        if (_frequency != null)
                        {
                            if (_tdp != null)
                            {
                                    if (_powerConsumption != null)
                                    {
                                        return new Cpu(_amountOfCores, _socket, _presenceOfVideoCore, _frequency, _tdp, _powerConsumption);
                                    }
                            }
                        }
                    }
                }

                throw new System.NotImplementedException();
        }
    }
}