using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedSet<string> elements = new SortedSet<string>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            foreach (var element in input)
            {
                elements.Add(element);
            }
        }
        Console.WriteLine(string.Join(" ", elements));
    }
}