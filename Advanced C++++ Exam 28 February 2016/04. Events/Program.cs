using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
//15:15
class Program
{
    static void Main()
    {
        string pattern = @"^#(?<person>[a-zA-Z]*):\s*@(?<location>[A-Za-z]*)\s*(?<time>(\d+):(\d+))$";
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, Dictionary<string, List<DateTime>>> cityNameTimes = new Dictionary<string, Dictionary<string, List<DateTime>>>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                int hours = int.Parse(match.Groups[1].Value);
                int minutes = int.Parse(match.Groups[2].Value);
                if (hours < 24 && minutes < 60)
                {
                    string location = match.Groups["location"].Value;
                    string person = match.Groups["person"].Value;
                    DateTime time = DateTime.ParseExact(match.Groups["time"].Value, "HH:mm", CultureInfo.InvariantCulture);
                    if (!cityNameTimes.ContainsKey(location))
                    {
                        cityNameTimes[location] = new Dictionary<string, List<DateTime>>();
                    }

                    if (!cityNameTimes[location].ContainsKey(person))
                    {
                        cityNameTimes[location][person] = new List<DateTime>();
                    }
                        cityNameTimes[location][person].Add(time);
                }
            }
        }

        string[] requestedLocations = Console.ReadLine().Split(',');

        foreach (var kvp in cityNameTimes.Where(x=>requestedLocations.Contains(x.Key)).OrderBy(x=>x.Key))
        {
            Console.WriteLine(kvp.Key+':');
            int counter = 0;
            foreach (var pair in kvp.Value.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{++counter}. {pair.Key} -> {string.Join(", ",pair.Value.OrderBy(x=>x).Select(x=>x.ToString("HH:mm")))}");
            }
        }
    }
}//16:00