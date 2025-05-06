using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainConsole;

public class ConnectHandler : AbstractHandler
{
    public override AbstractHandler? Handle(object request)
    {
        if ((request as string)?.Split().ToList()[0] == "connect")
        {
            return this;
        }

        return base.Handle(request);
    }

    public override void Print(string input, IContext context)
    {
        System.Console.WriteLine("--------------------------");
        System.Console.WriteLine(input);
        System.Console.WriteLine("--------------------------");
    }
}