namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public interface IFileSystem
{
    public string? Root { get; set; }
    public string? FilePath { get; set; }
}