using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileCommands;

public class DeleteCommand : ACustomCommand
{
    public override string Execute(IContext context)
    {
        if (context != null)
        {
            if (context.FileSystem != null)
            {
                File.Delete(context.Arguments[2]);
                return "deleted";
            }

            return "File system is not connected";
        }

        return "Nothing to delete";
    }
}