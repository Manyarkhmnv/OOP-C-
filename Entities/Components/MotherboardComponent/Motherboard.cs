using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CpuCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponent;

public class Motherboard : IMotherboard
{
    internal Motherboard(Socket socket, PciE pciE, SataPorts sataPorts, Chipset chipset, StandardDdr standardDdr, TablesRam tablesRam, FormFactorOfMotherboard formFactor)
    {
        Socket = socket;
        PciE = pciE;
        SataPorts = sataPorts;
        Chipset = chipset;
        StandardDdr = standardDdr;
        TablesRam = tablesRam;
        FormFactor = formFactor;
    }

    public static MotherboardBuilder Builder => new MotherboardBuilder();
    public Socket? Socket { get; set; }
    public PciE? PciE { get; set; }
    public SataPorts? SataPorts { get; set; }
    public Chipset? Chipset { get; set; }
    public StandardDdr? StandardDdr { get; set; }
    public TablesRam? TablesRam { get; set; }
    public FormFactorOfMotherboard? FormFactor { get; set; }
    public bool Equals(IFan? obj)
    {
        Socket? socket = this.Socket;
        return socket != null && obj != null && (obj.Socket != null) && this.Socket != null && socket.Equals(obj.Socket);
    }

    public bool Equals(ICpu? obj)
    {
        Socket? socket = this.Socket;
        return socket != null && obj != null && (obj.Socket != null) && this.Socket != null && socket.Equals(obj.Socket);
    }

    public bool Equals(RamComponent.Ram obj)
    {
        return StandardDdr != null && obj != null && (obj.StandardDdr != null) && StandardDdr.Equals(obj.StandardDdr);
    }

    public class MotherboardBuilder
    {
        private Socket? _socket;
        private PciE? _pciE;
        private SataPorts? _sataPorts;
        private Chipset? _chipset;
        private StandardDdr? _standardDdr;
        private TablesRam? _tablesRam;
        private FormFactorOfMotherboard? _formFactor;
        public MotherboardBuilder Add(Socket socket)
        {
            _socket = socket;
            return this;
        }

        public MotherboardBuilder Add(Chipset chipset)
        {
            _chipset = chipset;
            return this;
        }

        public MotherboardBuilder Add(PciE pciE)
        {
            _pciE = pciE;
            return this;
        }

        public MotherboardBuilder Add(SataPorts sataPorts)
        {
            _sataPorts = sataPorts;
            return this;
        }

        public MotherboardBuilder Add(StandardDdr standardDdr)
        {
            _standardDdr = standardDdr;
            return this;
        }

        public MotherboardBuilder Add(TablesRam tablesRam)
        {
            _tablesRam = tablesRam;
            return this;
        }

        public MotherboardBuilder Add(FormFactorOfMotherboard formFactorOfMotherboard)
        {
            _formFactor = formFactorOfMotherboard;
            return this;
        }

        public Motherboard Build()
        {
            if (_socket != null)
            {
                if (_pciE != null)
                {
                    if (_sataPorts != null)
                    {
                        if (_chipset != null)
                        {
                            if (_standardDdr != null)
                            {
                                if (_tablesRam != null)
                                {
                                    if (_formFactor != null)
                                    {
                                        return new Motherboard(_socket, _pciE, _sataPorts, _chipset, _standardDdr, _tablesRam, _formFactor);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            throw new System.NotImplementedException();
        }
    }
}