using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileCommands;

public class RenameCommand : ACustomCommand
{
    public override string Execute(IContext context)
    {
        if (context != null)
        {
            if (context.FileSystem != null)
            {
                var move = new MoveCommand();
                return move.Execute(context);
            }

            return "File system is not connected";
        }

        return "Nothing to rename";
    }
}