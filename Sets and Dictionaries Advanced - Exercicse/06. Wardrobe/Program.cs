using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, Dictionary<string, int>> colorClothesCount = new Dictionary<string, Dictionary<string, int>>();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split("->").Select(x => x.Trim()).ToArray();
            string[] clothes = input[1].Split(',');
            string color = input[0];
            if (!colorClothesCount.ContainsKey(color))
            {
                colorClothesCount[color] = new Dictionary<string, int>();
            }
            foreach (var clothing in clothes)
            {
                if (!colorClothesCount[color].ContainsKey(clothing))
                {
                    colorClothesCount[color][clothing] = 1;
                }
                else
                {
                    colorClothesCount[color][clothing]++;
                }
            }
        }
        string[] colorClothingFind = Console.ReadLine().Split(' ');
        foreach (var kvp in colorClothesCount)
        {
            Console.WriteLine("{0} clothes:", kvp.Key);
            foreach (var pair in kvp.Value)
            {
                Console.Write($"* {pair.Key} - {pair.Value}");
                if (kvp.Key == colorClothingFind[0] & pair.Key == colorClothingFind[1])
                {
                    Console.WriteLine(" (found!)");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}