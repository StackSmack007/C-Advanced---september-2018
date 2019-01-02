using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
class Program
{
    private static int doubleNameScopeValue;

    static void Main()
    {
        List<string> doubleNames = new List<string>();
        List<string> intNames = new List<string>();
        string pattern = @"(?<type>int|double)\s+(?<name>[a-z][\w]*)";

        string input;
        while ((input = Console.ReadLine()) != "//END_OF_CODE")
        {
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string type = match.Groups["type"].Value;
                string name = match.Groups["name"].Value;

                if (type == "int")
                {
                    intNames.Add(name);
                }
                else
                {
                    doubleNames.Add(name);
                }
            }
        }
        Console.WriteLine("Doubles: " + (doubleNames.Count == 0 ? "None" : string.Join(", ", doubleNames.OrderBy(x => x))));
        Console.WriteLine("Ints: " + (intNames.Count == 0 ? "None" : string.Join(", ", intNames.OrderBy(x => x))));
    }
}