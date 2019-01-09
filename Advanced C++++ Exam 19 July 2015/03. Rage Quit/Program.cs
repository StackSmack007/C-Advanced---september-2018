using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class Program
{//19:00
    static void Main()
    {
        string pattern = @"(?<message>[^\d]*)(?<count>\d+)";
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern);
        StringBuilder sb = new StringBuilder();
        foreach (Match match in matches)
        {
            for (int i = 0; i < int.Parse(match.Groups["count"].Value); i++)
            {
                sb.Append(match.Groups["message"].Value.ToUpper());
            }
        }
        string result = sb.ToString();
        int uniqueSymbols = result.Distinct().Count();
        Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
        Console.WriteLine(result);
    }
}//19:45