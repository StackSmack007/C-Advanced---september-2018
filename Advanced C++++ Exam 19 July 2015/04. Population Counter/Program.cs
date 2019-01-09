using System;
using System.Collections.Generic;
using System.Linq;
//18:45
class Program
{
    static void Main()
    {
        Dictionary<string, List<Town>> CountryTownPopullation = new Dictionary<string, List<Town>>();

        string input;
        while ((input = Console.ReadLine()) != "report")
        {
            string[] tokens = input.Split('|');
            string country = tokens[1];
            string town = tokens[0];
            int population = int.Parse(tokens[2]);
            if (!CountryTownPopullation.ContainsKey(country))
            {
                CountryTownPopullation[country] = new List<Town>();
            }
            Town current = new Town
            {
                Name = town,
                Population = population
            };
            int index = CountryTownPopullation[country].FindIndex(x => x.Name == town);
            if (index != -1)
            {
                CountryTownPopullation[country][index].Population = population;
            }
            else
            {
                CountryTownPopullation[country].Add(current);
            }
        }
        foreach (var kvp in CountryTownPopullation.OrderByDescending(x => x.Value.Sum(y => y.Population)))
        {
            Console.WriteLine($"{kvp.Key} (total population: {kvp.Value.Sum(y => y.Population)})");
            foreach (var town in kvp.Value.OrderByDescending(x => x.Population))
            {
                Console.WriteLine($"=>{town.Name}: {town.Population}");
            }
        }
    }
}
class Town
{
    public string Name { get; set; }
    public long Population { get; set; }
}//19:00