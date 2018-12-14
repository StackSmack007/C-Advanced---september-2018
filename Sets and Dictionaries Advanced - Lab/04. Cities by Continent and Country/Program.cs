using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, Dictionary<string, List<string>>> ContinentCountryCity = new Dictionary<string, Dictionary<string, List<string>>>();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            string continent = input[0];
            string country = input[1];
            string city = input[2];

           
            if (!ContinentCountryCity.ContainsKey(continent))
            {
                ContinentCountryCity[continent] = new Dictionary<string,List<string>>();
                ContinentCountryCity[continent][country] = new List<string> { city };
            }
            else
            {
                if (!ContinentCountryCity[continent].ContainsKey(country))
                {
                    ContinentCountryCity[continent][country] = new List<string> { city };
                }
                else if (!ContinentCountryCity[continent][country].Contains(city))
                {
                    ContinentCountryCity[continent][country].Add(city);
                }
            }
        }
        foreach (var kvp in ContinentCountryCity)
        {
            Console.WriteLine(kvp.Key+":");
            foreach (var pair in kvp.Value)
            {
                Console.WriteLine(pair.Key+" -> "+string.Join(", ",pair.Value));
            }
        }
    }
}