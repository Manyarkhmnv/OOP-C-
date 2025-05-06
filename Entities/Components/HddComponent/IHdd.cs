using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.HddComponent;

public interface IHdd : IDrive
{
    public Capacity? Capacity { get; protected set; }
    public SprindleSpeed? SprindleSpeed { get; protected set; }
}