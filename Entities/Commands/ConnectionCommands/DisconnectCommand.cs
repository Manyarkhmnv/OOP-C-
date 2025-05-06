using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.ConnectionCommands;

public class DisconnectCommand : ACustomCommand
{
    public override string Execute(IContext context)
    {
        if (context != null)
        {
            if (context.FileSystem != null)
            {
                context.FileSystem.FilePath = Directory.GetCurrentDirectory();
                context.FileSystem = null;
                return "Disconnect";
            }

            return "File system was not connected";
        }

        return "Nothing to disconnect";
    }
}