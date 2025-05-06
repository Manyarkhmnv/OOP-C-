using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.MotherboardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.VideoCardComponent;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.FrameComponent;

public class Frame : IFrame
{
    internal Frame(FormFactorOfMotherboard factorOfMotherboard, Dimensions dimensions, FormFactorOfFrame formFactorOfFrame)
    {
        FormFactorsOfMotherboard = factorOfMotherboard;
        FormFactorOfVideocard = dimensions;
        FormFactorOfFrame = formFactorOfFrame;
    }

    public static FrameBuilder Builder => new FrameBuilder();
    public FormFactorOfMotherboard? FormFactorsOfMotherboard { get; set; }
    public Dimensions? FormFactorOfVideocard { get; set; }
    public FormFactorOfFrame? FormFactorOfFrame { get; set; }
    public bool Equals(IVideoCard obj)
    {
        Dimensions? dimensions = this.FormFactorOfVideocard;
        return dimensions != null && obj != null && (obj.FormFactor != null) && obj.FormFactor.Equals(obj);
    }

    public bool Equals(IMotherboard obj)
    {
        return obj != null && (obj.FormFactor != null) && obj.FormFactor.Equals(this);
    }

    public class FrameBuilder
    {
        private FormFactorOfMotherboard? _formFactorsOfMotherboard;
        private Dimensions? _formFactorOfVideocard;
        private FormFactorOfFrame? _formFactorOfFrame;
        public FrameBuilder Add(FormFactorOfMotherboard formFactorOfMotherboard)
        {
            _formFactorsOfMotherboard = formFactorOfMotherboard;
            return this;
        }

        public FrameBuilder Add(Dimensions dimensions)
        {
            _formFactorOfVideocard = dimensions;
            return this;
        }

        public FrameBuilder Add(FormFactorOfFrame formFactorOfFrame)
        {
            _formFactorOfFrame = formFactorOfFrame;
            return this;
        }

        public Frame Build()
        {
            if (_formFactorsOfMotherboard != null)
            {
                if (_formFactorOfVideocard != null)
                {
                    if (_formFactorOfFrame != null)
                    {
                        return new Frame(_formFactorsOfMotherboard, _formFactorOfVideocard, _formFactorOfFrame);
                    }
                }
            }

            throw new System.NotImplementedException();
        }
    }
}