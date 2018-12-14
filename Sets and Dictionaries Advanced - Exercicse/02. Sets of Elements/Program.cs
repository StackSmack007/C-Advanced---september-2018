using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] setsCaps = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        HashSet<string> set1 = new HashSet<string>(setsCaps[0]);
        HashSet<string> set2 = new HashSet<string>(setsCaps[1]);
        for (int i = 0; i < setsCaps[0]; i++)
        {
            set1.Add(Console.ReadLine());
        }
        for (int i = 0; i < setsCaps[1]; i++)
        {
            set2.Add(Console.ReadLine());
        }
        var result = set1.Intersect(set2);
        Console.WriteLine(string.Join(" ", result));
    }
}