using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        Dictionary<string, List<string>> methodCalls = new Dictionary<string, List<string>>();
        int openBrackets = 0;
        string father = "";
        string methodPatern = @"(?<method>[A-Z][a-zA-Z]*)\s*\(";
        for (int i = 0; i < rows; i++)
        {
            string row = Console.ReadLine();
            MatchCollection methods = Regex.Matches(row, methodPatern);

            openBrackets += row.Contains('{') ? 1 : row.Contains('}') ? -1 : 0;
            foreach (Match method in methods)
            {
                if (methodCalls.Count == 0)
                {
                    openBrackets = 0;
                }
                string crntMtd = method.Groups["method"].Value;
                if (openBrackets == 0)
                {
                    father = method.Groups["method"].Value;
                    methodCalls[father] = new List<string>();
                }
                else
                {
                    methodCalls[father].Add(method.Groups["method"].Value);
                }
            }
        }
        foreach (var kvp in methodCalls.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value.Count} -> {string.Join(", ", kvp.Value.OrderBy(x => x))}");
        }
    }
}//40/100 Not Enough tests