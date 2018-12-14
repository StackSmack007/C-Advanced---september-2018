using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        SortedDictionary<char, int> result = new SortedDictionary<char, int>();
        string text = Console.ReadLine();
        foreach (char letter in text)
        {
            if (!result.ContainsKey(letter))
            {
                result[letter] = 1;
            }
            else
            {
                result[letter]++;
            }
        }
        foreach (var kvp in result)
        {
            Console.WriteLine("{0}: {1} time/s", kvp.Key, kvp.Value);
        }
    }
}