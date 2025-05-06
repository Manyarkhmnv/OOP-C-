using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeCommands;

public class TreeGotoCommand : ACustomCommand
{
    public override string Execute(IContext context)
    {
        if (context != null)
        {
            if (context.FileSystem != null)
            {
                Directory.SetCurrentDirectory(context.Arguments[2]);
                return context.Arguments[2];
            }

            return "File system is not connected";
        }

        return "Nothing to go to";
    }
}