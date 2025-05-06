using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileCommands;

public class MoveCommand : ACustomCommand
{
    public override string Execute(IContext context)
    {
        if (context != null)
        {
            if (context.FileSystem != null)
            {
                File.Move(context.Arguments[2], context.Arguments[3]);
                return context.Arguments[2];
            }

            return "File system is not connected";
        }

        return "Nothing to move";
    }
}