using System.Collections.Generic;
using System.Text.RegularExpressions;

static internal class CsvHelper
{
    public static string[] SplitCSV(string input)
    {
        var result = new List<string>();
                
        Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);

        foreach (Match match in csvSplit.Matches(input))
        {
            result.Add(match.Value.TrimStart(',').Trim('\"'));
        }

        return result.ToArray();
    }
}