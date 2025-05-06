namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public interface IHandler
{
    IHandler? SetNext(IHandler? handler);
    AbstractHandler? Handle(object request);
}