namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public abstract class AbstractHandler : IHandler
{
    private IHandler? _nextHandler;
    public IHandler? SetNext(IHandler? handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual AbstractHandler? Handle(object request)
    {
        if (_nextHandler != null)
        {
            return _nextHandler.Handle(request);
        }

        return null;
    }

    public abstract void Print(string input, IContext context);
}