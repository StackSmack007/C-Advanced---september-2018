using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
//12:25
class Program
{
    static void Main()
    {
        Dictionary<string, BigInteger> galaxyGreenMeteors = new Dictionary<string, BigInteger>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Count em all")
            {
                break;
            }
            string[] meteorArr = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            string galaxy = meteorArr[0];
            string colour = meteorArr[1];
            BigInteger quantity = BigInteger.Parse(meteorArr[2]) * (colour == "Green" ? 1 : colour == "Red" ? 1000000 : 1000000000000);
            if (!galaxyGreenMeteors.ContainsKey(galaxy))
            {
                galaxyGreenMeteors[galaxy] = 0;
            }
            if (quantity < 0 && galaxyGreenMeteors[galaxy] + quantity < 0)  continue;
            galaxyGreenMeteors[galaxy] += quantity;
        }
        foreach (var kvp in galaxyGreenMeteors.OrderByDescending(x => x.Value / 1000000000000).ThenBy(x => x.Key.Length).ThenBy(x => x.Key))
        {
            Console.WriteLine(kvp.Key);
            foreach (var pair in GetColoursOfMetheors(kvp.Value).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"-> {pair.Key} : {pair.Value}");
            }
        }
    }
    //70/100 because it can not specify +10 black -3 red and 2 green as a result. Subtracting screwes it...
    static Dictionary<string, BigInteger> GetColoursOfMetheors(BigInteger green)
    {
        var black = (green / 1000000000000);
        green -= black * 1000000000000;
        var red = (green / 1000000);
        green -= red * 1000000;
        var BRG = new Dictionary<string, BigInteger> { ["Black"] = black, ["Red"] = red, ["Green"] = green };
        return BRG;
    }
}
//13:00