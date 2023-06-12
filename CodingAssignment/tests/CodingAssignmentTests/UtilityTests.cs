using CodingAssignmentLib.Abstractions;
using CodingAssignmentLib;

namespace CodingAssignmentTests;

public class UtilityTest
{
    private Utilty _sut = null!;

    [SetUp]
    public void Setup()
    {
        _sut = new Utilty();
    }

    [Test]
    public void SearchKeyEqual()
    {
        var content = "aAaAa";
        List<Data> dataToSearchList = new List<Data> { new ("aaaaa", "bbbbb"), new("cccc", "dddd") };
        
        var dataList = _sut.searchFileWithKey(content, dataToSearchList);
        CollectionAssert.AreEqual(new List<Data>
        {
            new("aaaaa", "bbbbb")
        }, dataList);
    }
}