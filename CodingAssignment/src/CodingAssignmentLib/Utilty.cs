using CodingAssignmentLib;
using CodingAssignmentLib.Abstractions;

/* Utilty class that handle general functions*/
public class Utilty
{
    public string relativePath { get; set; }

    public IEnumerable<Data> searchKeyValuePair(string extensionName, string contentPath)
    {
        /* Takes in file extension name and the path to be read arguments, return a list of key-value pairs values*/
        switch (extensionName)
        {
            case ".csv":
                return new CsvContentParse().Parse(contentPath); break;
            case ".json":
                return new JsonContentParse().Parse(contentPath); break;
            case ".xml":
                return new XMLContentParse().Parse(contentPath); break;
            default:
                return Enumerable.Empty<Data>();
        }
    }

    public IEnumerable<Data> searchFileWithKey(string text, IEnumerable<Data>dataList)
    {
        /* Returns a list of key-value pairs if input text is a exact match to the key in the dataList */
        List<Data> resultList = new List<Data>();
        foreach (var item in dataList)
        {
            if (item.Key.ToLower().TrimEnd() == text.ToLower().TrimEnd())
            {
                resultList.Add(new Data { Key = item.Key, Value = item.Value, FileName = relativePath });
            }
        }
        return resultList;
    }
}

