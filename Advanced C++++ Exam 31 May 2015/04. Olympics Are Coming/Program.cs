using System;
using System.Collections.Generic;
using System.Linq;

//16:40
class Program
{
    static void Main()
    {
        Dictionary<string, CountryData> countryData = new Dictionary<string, CountryData>();
        string[] input = Console.ReadLine().Split(new char[] { '|' });
        while (input[0] != "report")
        {
            string countryName = string.Join(" ", input[1].Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries));
            string player = string.Join(" ", input[0].Trim().Split(new char[] { ' ','\t' }, StringSplitOptions.RemoveEmptyEntries));
            if (!countryData.ContainsKey(countryName))
            {
                countryData[countryName] = new CountryData();
            }
            if (!countryData[countryName].Players.Contains(player))
            {
                countryData[countryName].Players.Add(player);
            }
            countryData[countryName].Wins++;
            input = Console.ReadLine().Split(new char[] { '|' });
        }

        foreach (var kvp in countryData.OrderByDescending(x => x.Value.Wins))
        {
            Console.WriteLine($"{kvp.Key} ({kvp.Value.Players.Count} participants): {kvp.Value.Wins} wins");
        }
    }
}
class CountryData
{
    public List<string> Players { get; set; } = new List<string>();
    public int Wins { get; set; } = 0;
}//17:10