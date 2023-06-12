namespace CodingAssignmentLib.Abstractions;

public interface IFileUtility
{
    string GetExtension(string fileName);
    string GetContent(string fileName);
    string GetCurrentDirectory();
    string GetFileName(string fileName);
    string[] GetAllFileName(string directory);
    string GetRelativePath(string directory, string fileName);
}