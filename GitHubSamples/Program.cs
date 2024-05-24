using GitHubSamples.Classes;

namespace GitHubSamples;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        ReferenceTables referenceTables = new();
        var (success, exception) = await DataOperations.GetReferenceTables(referenceTables);
        if (success)
        {
            Console.WriteLine("Success reading to classes");
        }
        else
        {
            Console.WriteLine(exception.Message);
            Console.WriteLine($"Class operation failed with \n{exception.Message}");
        }

        var (success1, exception1, dataSet) = await DataOperations.GetReferenceTablesDataSet();
        if (success1)
        {
            Console.WriteLine("Success reading to DataSet");
        }
        else
        {
            Console.WriteLine($"DataSet operation failed with \n{exception1.Message}");
        }

        AnsiConsole.MarkupLine("[yellow]Press ENTER to exit[/]");
        Console.ReadLine();
    }
}