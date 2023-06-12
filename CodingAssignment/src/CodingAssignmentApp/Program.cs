// See https://aka.ms/new-console-template for more information

using System.IO;
using System.IO.Abstractions;
using System.Linq;
using CodingAssignmentLib;
using CodingAssignmentLib.Abstractions;
Console.WriteLine("Coding Assignment!");

do
{
    Console.WriteLine("\n---------------------------------------\n");
    Console.WriteLine("Choose an option from the following list:");
    Console.WriteLine("\t1 - Display");
    Console.WriteLine("\t2 - Search");
    Console.WriteLine("\t3 - Exit");

    switch (Console.ReadLine())
    {
        case "1":
            Display();
            break;
        case "2":
            Search();
            break;
        case "3":
            return;
        default:
            return;
    }
} while (true);


void Display()
{
    Console.WriteLine("Enter the name of the file to display its content:");

    var fileName = Console.ReadLine()!;
    var fileUtility = new FileUtility(new FileSystem());
    var utilty = new Utilty();

    var dataList = utilty.searchKeyValuePair(fileUtility.GetExtension(fileName), fileUtility.GetContent(fileName));

    Console.WriteLine("Data:");

    foreach (var data in dataList)
    {
        Console.WriteLine($"Key:{data.Key} Value:{data.Value}");
    }
}

void Search()
{
    Console.WriteLine("Enter the key to search.");
    string input = Console.ReadLine()!;

    var fileUtility = new FileUtility(new FileSystem());
    var utilty = new Utilty();
    string currDir = fileUtility.GetCurrentDirectory();
    const string folder = "\\data";
    string[] files = fileUtility.GetAllFileName(currDir + folder);
    
    List<Data> resultList = new List<Data>();

    foreach (string file in files)
    {
        var dataList = Enumerable.Empty<Data>();
        string fileName = fileUtility.GetFileName(file);
        string relativePath = fileUtility.GetRelativePath(currDir, file);
        utilty.relativePath = relativePath;

        dataList = utilty.searchKeyValuePair(
            fileUtility.GetExtension(fileName), 
            fileUtility.GetContent(relativePath)
        );

        if (dataList.Count() > 0)
        {
            resultList.AddRange(utilty.searchFileWithKey(input, dataList));
        }
    }

    foreach (Data d in resultList)
    {
        Console.WriteLine($"Key: {d.Key}, Value: {d.Value}, FileName: {d.FileName}");
    }
}