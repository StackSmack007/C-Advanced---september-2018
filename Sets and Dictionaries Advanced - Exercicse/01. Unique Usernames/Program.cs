using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        HashSet<string> names = new HashSet<string>(n);
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            names.Add(input);
        }
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}