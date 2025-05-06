using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuCoolingSystem;

public class Fan : IFan
{
    internal Fan(FormFactorOfCpuCoolingSystem formFactor, Socket socket, MaxTdp tdp)
    {
        FormFactor = formFactor;
        Socket = socket;
        MaxTdp = tdp;
    }

    public static FanBuilder Builder => new FanBuilder();
    public FormFactorOfCpuCoolingSystem? FormFactor { get; set; }
    public Socket? Socket { get; set; }
    public MaxTdp? MaxTdp { get; set; }
    public bool Equals(Cpu? obj)
    {
        MaxTdp? maxTdp = this.MaxTdp;
        return maxTdp != null && obj != null && (obj.Tdp != null) && this.MaxTdp != null && maxTdp.Equals(obj);
    }

    public class FanBuilder
    {
        private FormFactorOfCpuCoolingSystem? _formFactor;
        private Socket? _socket;
        private MaxTdp? _maxTdp;
        public FanBuilder Add(Socket socket)
        {
            _socket = socket;
            return this;
        }

        public FanBuilder Add(FormFactorOfCpuCoolingSystem factorOfCpuCoolingSystem)
        {
            _formFactor = factorOfCpuCoolingSystem;
            return this;
        }

        public FanBuilder Add(MaxTdp maxTdp)
        {
            _maxTdp = maxTdp;
            return this;
        }

        public Fan Build()
        {
            if (_formFactor != null)
            {
                if (_socket != null)
                {
                    if (_maxTdp != null)
                    {
                        return new Fan(_formFactor, _socket, _maxTdp);
                    }
                }
            }

            throw new System.NotImplementedException();
        }
    }
}