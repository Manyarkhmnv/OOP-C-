namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public abstract class ACustomCommand
{
    public abstract string Execute(IContext context);
}