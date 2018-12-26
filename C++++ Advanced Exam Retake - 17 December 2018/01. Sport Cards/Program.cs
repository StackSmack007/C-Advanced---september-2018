using System;
using System.Collections.Generic;
using System.Linq;
//10:20
class Program
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, decimal>> cardSportsPrices = new Dictionary<string, Dictionary<string, decimal>>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '-' ,'\t'}, StringSplitOptions.RemoveEmptyEntries);
            if (input[0] == "end")
            {
                break;
            }
            string cardName = input[1];
            if (input[0] == "check")
            {

                if (cardSportsPrices.ContainsKey(cardName))
                {
                    Console.WriteLine("{0} is available!", cardName);
                }
                else
                {
                    Console.WriteLine("{0} is not available!", cardName);
                }
                continue;
            }
            cardName = input[0];
            string sport = input[1];
            decimal price = decimal.Parse(input[2]);
            if (!cardSportsPrices.ContainsKey(cardName))
            {
                cardSportsPrices[cardName] = new Dictionary<string, decimal> { [sport] = price };
            }
            else
            {
                cardSportsPrices[cardName][sport] = price;
            }
        }
        foreach (var kvp in cardSportsPrices.OrderByDescending(x => x.Value.Count))
        {
            Console.WriteLine(kvp.Key + ":");
            foreach (var pair in kvp.Value.OrderBy(x => x.Key))
            {
                Console.WriteLine($"-{pair.Key} - {pair.Value:F2}");
            }
        }
    }
}
//10:50