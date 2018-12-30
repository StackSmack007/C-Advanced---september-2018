using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static int criticallMass;

    static void Main()
    {
        var galaxyTypesCounts = new Dictionary<string, Dictionary<string, long>>();
        int critMass = 1000000;

        while (true)
        {
            string[] input = Console.ReadLine().Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            if (input[0] == "Count em all")
            {
                break;
            }
            string galaxy = input[0];
            string type = input[1];
            int amaunt = int.Parse(input[2]);

            if (!galaxyTypesCounts.ContainsKey(galaxy))
            {
                galaxyTypesCounts[galaxy] = new Dictionary<string, long> { ["Black"] = 0, ["Red"] = 0, ["Green"] = 0 };
            }

            if (amaunt < 0)
            {
                galaxyTypesCounts[galaxy][type] += amaunt;
                continue;
            }


            if (type != "Black")
            {
                Evaluate(type, critMass, amaunt, galaxyTypesCounts[galaxy]);
                if (type == "Green")
                {
                    Evaluate("Red", critMass, 0, galaxyTypesCounts[galaxy]);
                }
            }
            else
            {
                galaxyTypesCounts[galaxy][type] += amaunt;
            }
        }
        foreach (var kvp in galaxyTypesCounts
            .OrderByDescending(x => x.Value["Black"])
            .ThenBy(x => x.Key.Length)
            .ThenBy(x => x.Key))
        {
            Console.WriteLine(kvp.Key);
            foreach (var pair in kvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"-> {pair.Key} : {pair.Value}");
            }
        }
    }

    static void Evaluate(string type, int critMass, int amaunt, Dictionary<string, long> book)
    {
        if (amaunt + book[type] >= critMass)
        {
            long newBestOnes = (amaunt + book[type]) / critMass;
            book[type == "Green" ? "Red" : "Black"] += newBestOnes;
            book[type] += amaunt - newBestOnes * critMass;
        }
        else
        {
            book[type] += amaunt;
        }
    }
}//100/100 Subtracting specific types works.