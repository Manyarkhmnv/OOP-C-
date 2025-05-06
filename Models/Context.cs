using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class Context : IContext
{
    public Context()
    {
        Arguments = new List<string>();
    }

    public IFileSystem? FileSystem { get; set; }
    public IList<string> Arguments { get; private set; }
    public void Add(IList<string> arguments)
    {
        Arguments = arguments;
    }
 }