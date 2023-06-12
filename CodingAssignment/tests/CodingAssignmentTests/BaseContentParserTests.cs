using CodingAssignmentLib.Abstractions;
using CodingAssignmentLib;

namespace CodingAssignmentTests;

public class BaseContentParserTests
{
    private CsvContentParse _csvSut = null!;
    private JsonContentParse _jsonSut = null!;

    [SetUp]
    public void Setup()
    {
        _csvSut = new CsvContentParse();
        _jsonSut = new JsonContentParse();
    }

    [Test]
    public void CSVParse_ReturnsData()
    {
        var content = "a,b" + Environment.NewLine + "c,d" + Environment.NewLine;
        var dataList = _csvSut.Parse(content).ToList();
        CollectionAssert.AreEqual(new List<Data>
        {
            new("a", "b"),
            new("c", "d")
        }, dataList);
    }

    [Test]
    public void JsonParse_ReturnsData()
    {
        var content = "[{\"Key\":\"75knWnMBov\",\"Value\":\"FYADSziM6C\"}]";
        var dataList = _jsonSut.Parse(content).ToList();
        CollectionAssert.AreEqual(new List<Data>
        {
            new("75knWnMBov", "FYADSziM6C")
        }, dataList);
    }

    [Test]
    public void JsonParse_DataType()
    {
        var content = "[{\"Key\":\"75knWnMBov\",\"Value\":\"FYADSziM6C\"}]";
        var dataList = _jsonSut.Parse(content).ToList();
        CollectionAssert.AllItemsAreInstancesOfType(dataList, typeof(Data));
    }


}

