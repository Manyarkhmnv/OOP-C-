using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.ConnectionCommands;

public class ConnectCommand : ACustomCommand
{
    private static LocalFileSystem _localFileSystem = new LocalFileSystem();
    private Dictionary<string, IFileSystem?> _commands = new()
    {
        { "local", _localFileSystem },
    };
    public override string Execute(IContext context)
    {
        if (context != null)
        {
            context.FileSystem = _commands[context.Arguments[3]];
            Directory.SetCurrentDirectory(context.Arguments[1]);
            _localFileSystem.FilePath = Directory.GetCurrentDirectory();
            _localFileSystem.Root = Directory.GetCurrentDirectory();
            return _localFileSystem.FilePath;
        }

        return "Nothing to connect";
    }
}