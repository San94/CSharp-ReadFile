using System.IO.Abstractions;
using CodingAssignmentLib.Abstractions;

namespace CodingAssignmentLib;

public class FileUtility : IFileUtility
{
    private readonly IFileSystem _fileSystem;

    public FileUtility(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }
    
    public string GetExtension(string fileName)
    {
        return _fileSystem.FileInfo.New(fileName).Extension;
    }

    public string GetContent(string fileName)
    {
        return _fileSystem.File.ReadAllText(fileName);
    }

    public string GetCurrentDirectory()
    {
        return _fileSystem.Directory.GetCurrentDirectory();
    }

    public string GetFileName(string fileName)
    {
        return _fileSystem.Path.GetFileName(fileName);
    }

    public string[] GetAllFileName(string directory)
    {
        return _fileSystem.Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
    }

    public string GetRelativePath(string directory, string fileName)
    {
        return _fileSystem.Path.GetRelativePath(directory, fileName);
    }
}