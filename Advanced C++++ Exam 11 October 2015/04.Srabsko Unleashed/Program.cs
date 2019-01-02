using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string pattern = @"^(?<singer>(\w*\s){1,3})@(?<town>(\w*\s){1,3})(?<ticketPrice>\d+)\s(?<ticketCount>\d+)$";
        Dictionary<string, Dictionary<string, int>> townSingerProffit = new Dictionary<string, Dictionary<string, int>>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }
            Match match = Regex.Match(input, pattern); if (!match.Success) continue;
            string town = match.Groups["town"].Value.Trim();
            string singer = match.Groups["singer"].Value.Trim();
            int proffit = int.Parse(match.Groups["ticketPrice"].Value) * int.Parse(match.Groups["ticketCount"].Value);
            if (!townSingerProffit.ContainsKey(town))
            {
                townSingerProffit[town] = new Dictionary<string, int>();
            }
            if (!townSingerProffit[town].ContainsKey(singer))
            {
                townSingerProffit[town][singer] = 0;
            }
            townSingerProffit[town][singer] += proffit;
        }
        foreach (var kvp in townSingerProffit)
        {
            Console.WriteLine(kvp.Key);
            foreach (var pair in kvp.Value.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"#  {pair.Key} -> {pair.Value}");
            }
        }
    }
}