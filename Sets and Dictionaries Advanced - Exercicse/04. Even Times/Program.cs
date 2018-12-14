using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, int> result = new Dictionary<string, int>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            if (!result.ContainsKey(input))
            {
                result[input] = 1;
            }
            else
            {
                result[input]++;
            }
        }
        foreach (var kvp in result.Where(x => x.Value % 2 == 0))
        {
            Console.WriteLine(kvp.Key);
        }
    }
}