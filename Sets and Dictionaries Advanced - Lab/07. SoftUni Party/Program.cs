using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<string> VIPguests = new HashSet<string>();
        HashSet<string> nonVIPguests = new HashSet<string>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "PARTY")
            {
                break;
            }
            if (input.Length == 8)
            {
                if (Char.IsDigit(input[0]))
                {
                    VIPguests.Add(input);
                }
                else
                {
                    nonVIPguests.Add(input);
                }
            }
        }
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            if (VIPguests.Contains(input))
            {
                VIPguests.Remove(input);
            }
            else if (nonVIPguests.Contains(input))
            {
                nonVIPguests.Remove(input);
            }
        }
        Console.WriteLine(VIPguests.Count + nonVIPguests.Count);
        foreach (var item in VIPguests)
        {
            Console.WriteLine(item);
        }
        foreach (var item in nonVIPguests)
        {
            Console.WriteLine(item);
        }
    }
}