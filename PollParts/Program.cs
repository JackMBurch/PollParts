using PollParts;
using TPSysIEI;

var path = "{YOUR PATH HERE}";
var files = Directory.GetFiles(path, "*.cmp", SearchOption.AllDirectories);
List<Output> outputList = new();
foreach (var file in files)
{
    FileInfo fi = new(file);
    string[] contents = File.ReadAllLines(file);
    try
    {
        List<Component> components = Component.Parse(contents);
        if (components.Count > 0)
        {
            var output = new Output
            {
                FileName = fi.Name,
                CreationTime = fi.CreationTime,
                PartsAdded = components.Count
            };
            outputList.Add(output);
            Console.WriteLine(output);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"{file}  ::  {e.Message}");
    }
}

List<string> lines = new();

foreach (Output o in outputList)
{
    lines.Add($"{CSVUtils.StringToCSVCell(o.FileName)},{CSVUtils.StringToCSVCell(o.CreationTime.ToString())},{CSVUtils.StringToCSVCell(o.PartsAdded.ToString())}");
}

File.WriteAllLines("cmpreport.csv", lines);