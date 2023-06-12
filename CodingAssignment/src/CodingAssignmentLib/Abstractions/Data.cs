namespace CodingAssignmentLib.Abstractions;

public struct Data
{
    public Data(string key, string value, string? file = null)
    {
        Key = key;
        Value = value;
        FileName = file;
    }
    public string Key { get; set; }
    public string Value { get; set; }
    public string FileName { get; set; }
}