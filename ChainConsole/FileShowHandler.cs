using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainConsole;

public class FileShowHandler : AbstractHandler
{
    public override AbstractHandler? Handle(object request)
    {
        if ((request as string) == "file")
        {
            return this;
        }

        return base.Handle(request);
    }

    public override void Print(string input, IContext context)
    {
        System.Console.WriteLine("==========================");
        System.Console.WriteLine(input);
        System.Console.WriteLine("==========================");
    }
}