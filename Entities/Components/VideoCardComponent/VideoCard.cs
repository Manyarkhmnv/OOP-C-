using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;
namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.VideoCardComponent;

public class VideoCard : IVideoCard
{
    internal VideoCard(Dimensions formFactor, VideoMemory videoMemory, PciE pciE, ChipFrequency chipFrequency, PowerConsumption powerConsumption)
    {
        FormFactor = formFactor;
        AmountOfVideoMemory = videoMemory;
        AmountOfPciELines = pciE;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public static VideoCardBuilder Builder => new VideoCardBuilder();
    public Dimensions? FormFactor { get; set; }
    public VideoMemory? AmountOfVideoMemory { get; set; }
    public PciE? AmountOfPciELines { get; set; }
    public ChipFrequency? ChipFrequency { get; set; }
    public PowerConsumption? PowerConsumption { get; set; }

    public class VideoCardBuilder
    {
        private Dimensions? _formFactor;
        private VideoMemory? _amountOfVideoMemory;
        private PciE? _amountOfPciELines;
        private ChipFrequency? _chipFrequency;
        private PowerConsumption? _powerConsumption;
        public VideoCardBuilder Add(Dimensions formFactor)
        {
            _formFactor = formFactor;
            return this;
        }

        public VideoCardBuilder Add(VideoMemory amountOfVideoMemory)
        {
            _amountOfVideoMemory = amountOfVideoMemory;
            return this;
        }

        public VideoCardBuilder Add(PciE amountOfPciELines)
        {
            _amountOfPciELines = amountOfPciELines;
            return this;
        }

        public VideoCardBuilder Add(ChipFrequency chipFrequency)
        {
            _chipFrequency = chipFrequency;
            return this;
        }

        public VideoCardBuilder Add(PowerConsumption powerConsumption)
        {
            _powerConsumption = powerConsumption;
            return this;
        }

        public VideoCard Build()
        {
            if (_chipFrequency != null)
            {
                if (_amountOfPciELines != null)
                {
                    if (_amountOfVideoMemory != null)
                    {
                        if (_formFactor != null)
                        {
                            if (_powerConsumption != null)
                            {
                                return new VideoCard(_formFactor, _amountOfVideoMemory, _amountOfPciELines, _chipFrequency, _powerConsumption);
                            }
                        }
                    }
                }
            }

            throw new System.NotImplementedException();
        }
    }
}