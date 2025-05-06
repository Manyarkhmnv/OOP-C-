using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainConsole;

public class TreeGotoHandler : AbstractHandler
{
    public override AbstractHandler? Handle(object request)
    {
        if ((request as string) == "tree")
        {
            return this;
        }
        else
        {
            return base.Handle(request);
        }
    }

    public override void Print(string input, IContext context)
    {
        System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
        string? mainPath = Client.Root;
        if (input != null)
        {
            var paths = input.Split(" ").ToList();
            paths.RemoveAt(paths.Count - 1);
            foreach (string path in paths)
            {
                if (mainPath != null) System.Console.WriteLine(HowDeepRabbitHole(StripPrefix(path, mainPath)));
            }
        }

        System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    public override string ToString()
    {
        return "tree";
    }

    private static string HowDeepRabbitHole(string text)
    {
        if (text.Count(f => f == '\\') - 1 >= 0)
        {
            int count = text.Count(f => f == '\\') - 1;
            return "|" + new string('_', count) + text;
        }

        return " ";
    }

    private static string StripPrefix(string text, string prefix)
    {
        for (int i = 0; i < prefix.Length; i++)
        {
            if (prefix[0] != text[0])
            {
                return text;
            }
        }

        return text.Substring(prefix.Length);
    }
}