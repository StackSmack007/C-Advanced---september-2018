using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        HashSet<string> names = new HashSet<string>();
        for (int i = 0; i < n; i++)
        {
            names.Add(Console.ReadLine());
        }
        foreach (var item in names)
        {
            Console.WriteLine(item);
        }
    }
}