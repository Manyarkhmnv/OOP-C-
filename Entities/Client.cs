using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.ChainConsole;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.ConnectionCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class Client
{
    private static readonly ConnectHandler ConnectHandler = new ConnectHandler();
    private static readonly DisConnectHandler DisConnectHandler = new DisConnectHandler();
    private static readonly TreeListHandler TreeListHandler = new TreeListHandler();
    private static readonly TreeGotoHandler TreeGotoHandler = new TreeGotoHandler();
    private static readonly FileShowHandler FileShowHandler = new FileShowHandler();
    private static readonly FileCopyHandler FileCopyHandler = new FileCopyHandler();
    private static readonly FileDeleteHandler FileDeleteHandler = new FileDeleteHandler();
    private static readonly FileMoveHandler FileMoveHandler = new FileMoveHandler();
    private static readonly FileRenameHandler FileRenameHandler = new FileRenameHandler();

    private static readonly ConnectCommand Connect = new ConnectCommand();
    private static readonly DisconnectCommand Disconnect = new DisconnectCommand();
    private static readonly TreeGotoCommand TreeGotoCommand = new TreeGotoCommand();
    private static readonly TreeListCommand TreeListCommand = new TreeListCommand();
    private static readonly CopyCommand CopyCommand = new CopyCommand();
    private static readonly DeleteCommand DeleteCommand = new DeleteCommand();
    private static readonly MoveCommand MoveCommand = new MoveCommand();
    private static readonly RenameCommand RenameCommand = new RenameCommand();
    private static readonly ShowCommand ShowCommand = new ShowCommand();
    private static Dictionary<string, ACustomCommand> _treecommands = new()
    {
        { "goto", TreeGotoCommand },
        { "list", TreeListCommand },
    };

    private static Dictionary<string, ACustomCommand> _connectcommands = new()
    {
        { "connect", Connect },
        { "disconnect", Disconnect },
    };
    private static Dictionary<string, ACustomCommand> _filecommands = new()
    {
        { "show", ShowCommand },
        { "move", MoveCommand },
        { "copy", CopyCommand },
        { "delete", DeleteCommand },
        { "rename", RenameCommand },
    };

    private static Dictionary<string, AbstractHandler> _treehandlers = new()
    {
        { "goto", TreeGotoHandler },
        { "list", TreeListHandler },
    };

    private static Dictionary<string, AbstractHandler> _connecthandlers = new()
    {
        { "connect", ConnectHandler },
        { "disconnect", DisConnectHandler },
    };
    private static Dictionary<string, AbstractHandler> _filehandlers = new()
    {
        { "show", FileShowHandler },
        { "move", FileMoveHandler },
        { "copy", FileCopyHandler },
        { "delete", FileDeleteHandler },
        { "rename", FileRenameHandler },
    };
    private Dictionary<string, Dictionary<string, ACustomCommand>> _commands = new()
    {
        { "connect", _connectcommands },
        { "disconnect", _connectcommands },
        { "tree", _treecommands },
        { "file", _filecommands },
    };
    private Dictionary<string, Dictionary<string, AbstractHandler>> _handlers = new()
    {
        { "connect", _connecthandlers },
        { "disconnect", _connecthandlers },
        { "tree", _treehandlers },
        { "file", _filehandlers },
    };

    public Client()
    {
        ConnectHandler.SetNext(FileDeleteHandler)?.SetNext(FileMoveHandler)?.SetNext(FileCopyHandler)?.SetNext(FileRenameHandler)?.SetNext(FileShowHandler)?.SetNext(TreeGotoHandler)?.SetNext(TreeListHandler)?.SetNext(DisConnectHandler);
    }

    public static string? Root { get; set; }
    public static string? FilePath { get; set; }
    public void Execute(IContext context)
    {
        if (context != null)
        {
            string result;
            if (context.Arguments[0] == "connect" || (context.Arguments[0] == "disconnect"))
            {
                result = _commands[context.Arguments.First()][context.Arguments[0]].Execute(context);
            }
            else
            {
                result = _commands[context.Arguments.First()][context.Arguments[1]].Execute(context);
            }

            if (context.FileSystem == null)
            {
                System.Console.WriteLine(result);
            }
            else if (result != null)
            {
                AbstractHandler? handle;
                if (context.Arguments[0] == "connect" || (context.Arguments[0] == "disconnect"))
                {
                    handle = _handlers[context.Arguments.First()][context.Arguments[0]].Handle($"{context.Arguments.First()}");
                }
                else
                {
                    handle = _handlers[context.Arguments.First()][context.Arguments[1]].Handle($"{context.Arguments.First()}");
                }

                handle?.Print(result, context);
            }
            else
            {
                System.Console.WriteLine("Command not found");
            }
        }
    }
}