using Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SsdDriveComponent;

public interface ISsdDrive : IDrive
{
    public ConnectionOptionForSsd? ConnectionOption { get; protected set; }
    public Capacity? Capacity { get; protected set; }
    public SpeedOfWork? SpeedOfWork { get; protected set; }
}