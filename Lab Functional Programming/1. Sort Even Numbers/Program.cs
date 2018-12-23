using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine(string.Join(", ", Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .Where(x => x % 2 == 0)
            .OrderBy(x => x)));
    }
}

