using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IDrive
{
    public PowerConsumption? PowerConsumption { get; protected set; }
}