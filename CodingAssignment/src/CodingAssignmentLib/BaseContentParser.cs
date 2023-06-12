using CodingAssignmentLib.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace CodingAssignmentLib;

public abstract class BaseContentParser : IContentParser
{
    public abstract IEnumerable<Data> Parse(string content);
}

public class CsvContentParse : BaseContentParser
{
    public override IEnumerable<Data> Parse(string content)
    {
        return content.Split(new[] { "\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries).Select(line =>
        {
            var items = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            return new Data(items[0], items[1]);
        });
    }
}

public class JsonContentParse : BaseContentParser
{
    public override IEnumerable<Data> Parse(string content)
    {
        JsonDocument jsonDoc = JsonDocument.Parse(content);
        List<Data> dataList = new List<Data>();

        foreach (JsonElement item in jsonDoc.RootElement.EnumerateArray())
        {
            string key = item.GetProperty("Key").GetString();
            string value = item.GetProperty("Value").GetString();
            dataList.Add(new Data(key, value));
        }
        return dataList;
    }
}

public class XMLContentParse : BaseContentParser
{
    public override IEnumerable<Data> Parse(string content)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(content);
        List<Data> result = new List<Data>();

        XmlNodeList nodes = doc.GetElementsByTagName("Data");

        foreach (XmlNode node in nodes)
        {
            string key = node.SelectSingleNode("Key").InnerText;
            string value = node.SelectSingleNode("Value").InnerText;
            result.Add(new Data(key, value));
        }
        return result;
    }
}
