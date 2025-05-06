using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.RamComponent;

public class Ram : IRam
{
    internal Ram(Memory memory, ChipFrequency frequency, FormFactorOfRam formFactorOfRam, StandardDdr standardDdr, PowerConsumption powerConsumption)
    {
        Memory = memory;
        Frequency = frequency;
        FormFactor = formFactorOfRam;
        StandardDdr = standardDdr;
        PowerConsumption = powerConsumption;
    }

    public static RamBuilder Builder => new RamBuilder();
    public Memory? Memory { get; set; }
    public ChipFrequency? Frequency { get; set; }
    public FormFactorOfRam? FormFactor { get; set; }
    public StandardDdr? StandardDdr { get; set; }
    public PowerConsumption? PowerConsumption { get; set; }

    public class RamBuilder
    {
        private Memory? _memory;
        private ChipFrequency? _frequency;
        private FormFactorOfRam? _formFactor;
        private StandardDdr? _standardDdr;
        private PowerConsumption? _powerConsumption;
        public RamBuilder Add(Memory memory)
        {
            _memory = memory;
            return this;
        }

        public RamBuilder Add(ChipFrequency chipFrequency)
        {
            _frequency = chipFrequency;
            return this;
        }

        public RamBuilder Add(FormFactorOfRam formFactorOfRam)
        {
            _formFactor = formFactorOfRam;
            return this;
        }

        public RamBuilder Add(StandardDdr standardDdr)
        {
            _standardDdr = standardDdr;
            return this;
        }

        public RamBuilder Add(PowerConsumption powerConsumption)
        {
            _powerConsumption = powerConsumption;
            return this;
        }

        public Ram Build()
        {
            if (_memory != null)
            {
                if (_formFactor != null)
                {
                    if (_frequency != null)
                    {
                        if (_standardDdr != null)
                        {
                            if (_powerConsumption != null)
                            {
                                return new Ram(_memory, _frequency, _formFactor, _standardDdr, _powerConsumption);
                            }
                        }
                    }
                }
            }

            throw new System.NotImplementedException();
        }
    }
}