namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GeneralCharacteristics;

public class PresenceOfVideoCore : ICharacteristics
{
    public PresenceOfVideoCore(bool presence)
    {
        Presence = presence;
    }

    public bool Presence { get; }
}