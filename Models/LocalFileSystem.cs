namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class LocalFileSystem : IFileSystem
{
    public string? Root { get; set; }
    public string? FilePath { get; set; }
}