using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public interface IContext
{
    public IFileSystem? FileSystem { get; protected internal set; }
    public IList<string> Arguments { get; }

    public void FileInit(string rootDirectory)
    {
        if (FileSystem != null)
        {
            FileSystem.Root = rootDirectory;
            FileSystem.FilePath = ".";
        }
    }
}