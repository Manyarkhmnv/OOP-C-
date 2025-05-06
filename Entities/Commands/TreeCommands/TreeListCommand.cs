using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeCommands;

public class TreeListCommand : ACustomCommand
{
    public override string Execute(IContext context)
    {
#pragma warning disable CA1305
        if (context != null)
        {
            if (context.FileSystem != null)
            {
                return GetTree(int.Parse(context.Arguments[3]));
            }

            return "File system is not connected";
        }
#pragma warning restore CA1305
        return "Nothing";
    }

    public string GetTree(int depth)
    {
        List<FileInfo> a = FindFiles(new List<FileInfo>(), Directory.GetCurrentDirectory(), depth);
        return a.Aggregate(string.Empty, string (current, variable) => current + variable.ToString() + " ");
    }

    private List<FileInfo> FindFiles(List<FileInfo> results, string dir, int depth)
    {
        results.AddRange(new DirectoryInfo(dir).GetFiles("*"));
        if (depth > 1)
        {
            foreach (DirectoryInfo d in new DirectoryInfo(dir).GetDirectories())
            {
                FindFiles(results, d.FullName, depth - 1);
            }
        }

        return results;
    }
}